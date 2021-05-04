using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace activity13
{
    public class movie : IComparable<movie>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }

        public int CompareTo([AllowNull] movie other)
        {
            return this.Duration.CompareTo(other.Duration);
        }
        public void TakeMovieDetails()
        {
            Console.WriteLine("please enter a movie name");
            Name = Console.ReadLine();
            double duration = 0;
            Console.WriteLine("please enter the movie duration");
            while (!double.TryParse(Console.ReadLine(), out duration))
            {
                Console.WriteLine("INVALID ENTRY FOR DURATION.PLEASE TRY AGAIN");
            }
            Duration = duration;
        }

        public override string ToString()
        {
            return "id:" + Id + "name:" + Name + "duration:" + Duration;
        }
    }
}
