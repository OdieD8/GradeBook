using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    [TestClass]
    public class TypeTests
    {
        int count = 0;
        [TestMethod]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.AreEqual(3, count);
        }
        [TestMethod]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(out x);

            Assert.AreEqual(42, x);
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        private void SetInt(out int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [TestMethod]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book1");
            SetName(book1, "New Name");

            Assert.AreEqual("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [TestMethod]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book1");
            GetBookSetName(book1, "New Name");

            Assert.AreEqual("Book1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        }

        [TestMethod]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book1");
            GetBookSetName(ref book1, "New Name");

            Assert.AreEqual("New Name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        }

        [TestMethod]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            // act

            // assert
            Assert.AreEqual("Book 1", book1.Name);
            Assert.AreEqual("Book 2", book2.Name);
        }

        [TestMethod]
        public void TwoVarsCanReferenceSameObject()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;
            // act

            // assert
            Assert.AreEqual("Book 1", book1.Name);
            Assert.AreEqual("Book 1", book2.Name);
            Assert.AreSame(book1, book2);
            Assert.IsTrue(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
