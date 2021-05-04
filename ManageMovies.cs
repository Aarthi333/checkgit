using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace activity13
{
    class ManageMovies
    {
        Dictionary<int,movie> movies;
        public ManageMovies()
        {
            movies = new Dictionary<int, movie>();
        }
        private int GenerateId()
        {
            if (movies.Count == 0)
                return 1;
            int id = movies[movies.Count - 1].Id;
            id++;
            return id;
        }
        public movie CreateMovie()
        {
            movie Movie = new movie();
            Movie.Id = GenerateId();
            Movie.TakeMovieDetails();
            return Movie;
        }
        public int GetMovieIndexById(int id)
        {
            List<KeyValuePair<int, movie>> mlist = movies.ToList();
            return mlist.FindIndex(m => m.Key == id );                  //Lambda Expression
        }

        public movie UpdateMovieName(int id, string name)
        {
            movie Movie = null;
            int idx = GetMovieIndexById(id);
            if (idx != -1)
            {
                movies[idx].Name = name;
                Movie = movies[idx];
            }
            return Movie;
        }
        private void PrintMovieById()
        {
            Console.WriteLine("please enter the movie id ");
            int id = Convert.ToInt32(Console.ReadLine());
            int idx = GetMovieIndexById(id);
            if (idx >= 0)
                PrintMovie(movies[idx]);
            else
                Console.WriteLine("no such movie");
        }
        private void DeleteMovie()
        {
            Console.WriteLine("please enter the movie id to be deleted");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                movies.Remove(GetMovieIndexById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("oops something went wrong ..please try again!");
            }
        }
        public movie UpdateMovieDuration(int id, double duration)
        {
            movie Movie = null;
            int idx = GetMovieIndexById(id);
            if (idx != -1)
            {
                movies[idx].Duration = duration;
                Movie = movies[idx];
            }
            return Movie;
        }
        public void PrintMovieById(int id)
        {
            int idx = GetMovieIndexById(id);
            if (idx != -1)
            {
                PrintMovie(movies[idx]);
            }
            else
                Console.WriteLine("no such movie");
        }

        public void PrintAllMovie()
        {
            if (movies.Count == 0)
                Console.WriteLine("no movies present");
            else
            {
                foreach (var item in movies.Keys)
                {
                    PrintMovie(movies[item]);
                }
            }
        }
        void AddMovies()
        {
            int choice = 0;
            do
            {
                movie Movie = CreateMovie();
                movies.Add(Movie.Id,Movie);
                Console.WriteLine("do you wish to add another movie.if yes enter a number other than 0 .to exit enter 0");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException formatexception)
                {
                    Console.WriteLine("not a correct input");
                }

            } while (choice != 0);
        }

        public void SortMovies()
        {
            if (movies.Count != 0)
            {
                movies.OrderBy(i => i.Key);
            }
            else
                Console.WriteLine("no elements to be sorted");
        }
        public void PrintMovie(movie Movie)
        {
            Console.WriteLine("_______________________");
            Console.WriteLine(Movie);
            Console.WriteLine("________________________");
        }
        void UpdateMovie()
        {
            Console.WriteLine("please enter the movie id for updation");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("what do you want to update name or duration or both");
            string choice = Console.ReadLine();
            string name;
            double duration;
            switch (choice)
            {
                case "name":
                    Console.WriteLine("please enter the new name");
                    name = Console.ReadLine();
                    UpdateMovieName(id, name);
                    break;
                case "duration":
                    Console.WriteLine("please enter the new duration");
                    while (!double.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("invalid entry for duration .please try again");
                    }
                    UpdateMovieDuration(id, duration);
                    break;
                case "both":
                    Console.WriteLine("please enter the new name");
                    name = Console.ReadLine();
                    UpdateMovieName(id, name);
                    Console.WriteLine("please enter the new duration:");
                    while (!double.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("invalid entry for duration .please try again");
                    }
                    UpdateMovieDuration(id, duration);
                    break;
                default:
                    Console.WriteLine("invalid choice");
                    break;
            }
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("menu");
                Console.WriteLine("1.ADD a movie");
                Console.WriteLine("2.ADD a list of  movie");
                Console.WriteLine("3.update the movie");
                Console.WriteLine("4.delete the movie");
                Console.WriteLine("5.print  movie by id");
                Console.WriteLine("6.print all movies");
                Console.WriteLine("7.sort the movies by duration");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        movie Movie = CreateMovie();
                        movies.Add(Movie.Id,Movie);
                        break;
                    case 2:
                        AddMovies();
                        break;
                    case 3:
                        UpdateMovie();
                        break;
                    case 4:
                        DeleteMovie();
                        break;
                    case 5:
                        PrintMovieById();
                        break;
                    case 6:
                        PrintAllMovie();
                        break;
                    case 7:
                        SortMovies();
                        break;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            } while (choice != 8);

        }

        static void Main(string[] a)
        {
            ManageMovies manageMovies = new ManageMovies();
            manageMovies.PrintMenu();

        }

    }
}
