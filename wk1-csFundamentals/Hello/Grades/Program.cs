using System;

namespace Grades {
    internal class Program {
        private static void Main(string[] args) {
            IGradeTracker book = CreateGradeBook();

            //book.NameChanged += OnNameChanged;

            Console.WriteLine("Enter a name:");
            try {
                //book.Name = Console.ReadLine();
            } catch (ArgumentException ex) {
                Console.WriteLine(ex.Message);
                //book.Name = "Empty";
            } finally {

            }
            AddGrades(book);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average",stats.AverageGrade);
            WriteResult("Highest",(int)stats.AverageGrade);
            WriteResult("Lowest",stats.LowestGrade);
            WriteResult(stats.Description,stats.LetterGrade);
        }

        private static IGradeTracker CreateGradeBook() {
            return new RemoveLowestGradeBook();
        }

        private static void AddGrades(IGradeTracker book) {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
            book.WriteGrades(Console.Out);
        }

        private static void OnNameChanged(object sender,NameChangedEventArgs args) {
            Console.WriteLine($"Sender {sender} notified GradeBook of name change from {args.ExistingName} to {args.NewName}");
        }

        private static void WriteResult(string description,float result) {
            Console.WriteLine(description + ": " + result);
        }

        private static void WriteResult(string description,int result) {
            Console.WriteLine(description + ": " + result);
        }

        private static void WriteResult(string description,string result) {
            Console.WriteLine(description + ": " + result);
        }
    }
}
