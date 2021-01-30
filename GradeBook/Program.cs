using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Scott's Grade Book");
            book.GradeAdded += OnGradeAdded;
            
            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"The category is {InMemoryBook.CATEGORY}");
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
            Console.ReadLine();
        }

        private static void EnterGrades(IBook book)
        {
            var answer = String.Empty;
            while (answer != "Q")
            {
                Console.WriteLine("Enter a number grade or 'q' to exit");
                answer = Console.ReadLine().ToUpper();
                Console.WriteLine();
                if (answer == "Q")
                {
                    break;
                }
                try
                {
                    book.AddGrade(Convert.ToDouble(answer));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //this will run regardless of exceptions caught
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
