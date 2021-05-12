using System;
using System.Linq;

namespace Day19
{
    class Program
    {
        int[] feedbackScores = { 45, 99, 87, 67, 56, 42, 32, 47, 1 }; 

        void PrintLowFeedbackCount()
        {
            //using linq in collections
            var Count = feedbackScores.Where(score => score < 60).Count();   //passing a predicate instead of query syntax(from n ...)
            Console.WriteLine("the number of feedbacks less than 60 is " +Count);

        }
        void PrintFeedbackInAscendingOrder()
        {
            var SortedFeedback = feedbackScores.OrderBy(score => score);
            foreach (var item in SortedFeedback)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Program().PrintLowFeedbackCount();
            new Program().PrintFeedbackInAscendingOrder();
        }
    }
}
