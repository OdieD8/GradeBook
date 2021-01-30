using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GradeBook.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("Book Test");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.AreEqual(85.6, result.Average, 1);
            Assert.AreEqual(90.5, result.High);
            Assert.AreEqual(77.3, result.Low);
            Assert.AreEqual('B', result.Letter);
        }
        [TestMethod]
        public void AddOnlyValidGradeRange()
        {
            var book = new InMemoryBook("Book Test");
            book.AddGrade(5.1);

            var result = book.GetStatistics();

            Assert.AreEqual(5.1, result.High);
        }
    }
}
