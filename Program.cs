using System;
using System.Data;
using System.Data.SqlClient;
namespace ADOsampleProject
{
    class Program
    {
        string constring;
        SqlConnection con;
        SqlCommand cmd;
        //SqlCommand cmd2;

        public Program()
        {
            constring = @"server=LAPTOP-V7NNEK9K;Integrated security= true ; Initial catalog = pubs";
            con = new SqlConnection(constring);

        }
        void FetchMoviesFromDatabase()
        {
            string strCmd = "Select * from tb1Movie";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("MOVIE ID:" + drMovies[0].ToString());
                    Console.WriteLine("MOVIE NAME:" + drMovies[1]);
                    Console.WriteLine("MOVIE DURATION:" + drMovies[2].ToString());
                    //Console.WriteLine("AUTHOR PHONE:" + drAuthors[3]);
                    Console.WriteLine("_________________________");
                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            finally //will get executed if there is or if there is no exception
            {
                con.Close();
            }
        }
        void FetchOneMovieFromDatabase()
        {
            string strCmd = "Select * from tb1Movie where id= @mid";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                Console.WriteLine("please enter the id");
                int id = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.Add("@mid", SqlDbType.Int);
                cmd.Parameters[0].Value = id;   //another method to value 
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("MOVIE ID:" + drMovies[0].ToString());
                    Console.WriteLine("MOVIE NAME:" + drMovies[1]);
                    Console.WriteLine("MOVIE DURATION:" + drMovies[2].ToString());
                    //Console.WriteLine("AUTHOR PHONE:" + drAuthors[3]);
                    Console.WriteLine("_________________________");
                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            finally //will get executed if there is or if there is no exception
            {
                con.Close();
            }
        }

        void CountAuthorId()  //counts authorID from authors in pubs database
        {
            string strCmd = "select COUNT(au_id) from authors;";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                SqlDataReader drAuthors = cmd.ExecuteReader();
                while (drAuthors.Read())
                {
                    Console.WriteLine("the count of au id is " + drAuthors[0]);
                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                con.Close();
            }


        }

        void UpdateMovie()
            {
                Console.WriteLine("please enter the id ");
                int id  = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("please enter the movie duration");
                float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()));
                string strCmd = "update tb1Movie set duration = @mduration where id=@mid";
                cmd = new SqlCommand(strCmd, con);
                cmd.Parameters.AddWithValue("@mid", id);
                cmd.Parameters.AddWithValue("@mduration", mDuration);
                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery(); //because we are not executing the query
                    if(result>0)
                        Console.WriteLine("movie updated");
                    else
                        Console.WriteLine("no not done");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    con.Close();
                }


            }

        void AddMovie()
        {
            Console.WriteLine("please enter the movie name");
            string mName = Console.ReadLine();
            Console.WriteLine("please enter the movie duration");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()));
            string strCmd = "insert into tb1Movie(name,duration) values(@mname,@mdur)";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mname", mName);
            cmd.Parameters.AddWithValue("@mdur", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery(); //because we are not executing the query
                if (result > 0)
                    Console.WriteLine("movie inserted");
                else
                    Console.WriteLine("no not done");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }


        }

        void DeleteMovie()
        {
            Console.WriteLine("please enter the id ");
            int id = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("please enter the movie duration");
            //float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()));
            string strCmd = "delete from tb1Movie where id = @mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery(); //because we are not executing the query
                if (result > 0)
                    Console.WriteLine("movie deleted");
                else
                    Console.WriteLine("no not done");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }

        }
        void SortMovies()
        {
            string strCmd = "Select * from tb1Movie ORDER BY duration ";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("MOVIE ID:" + drMovies[0].ToString());
                    Console.WriteLine("MOVIE NAME:" + drMovies[1]);
                    Console.WriteLine("MOVIE DURATION:" + drMovies[2].ToString());
                    //Console.WriteLine("AUTHOR PHONE:" + drAuthors[3]);
                    Console.WriteLine("_________________________");
                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            finally //will get executed if there is or if there is no exception
            {
                con.Close();
            }
        }

        void UpdateMovieChoice()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1.UPDATE THE MOVIE NAME");
                Console.WriteLine("2.UPDATE THE MOVIE DURATION");
                Console.WriteLine("3.EXIT");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("please enter the id ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("please enter the NEW movie name");
                        string mname = Console.ReadLine();
                        string strCmd = "update tb1Movie set name = @mname where id=@mid";
                        cmd = new SqlCommand(strCmd, con);
                        cmd.Parameters.AddWithValue("@mid", id);
                        cmd.Parameters.AddWithValue("@mname", mname);
                        try
                        {
                            con.Open();
                            int result = cmd.ExecuteNonQuery(); //because we are not executing the query
                            if (result > 0)
                                Console.WriteLine("movie name updated");
                            else
                                Console.WriteLine("no not done");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                        break;
                    case 2:
                        Console.WriteLine("please enter the id ");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("please enter the movie duration");
                        float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()));
                        string strCmd2 = "update tb1Movie set duration = @mduration where id=@mid";
                        cmd = new SqlCommand(strCmd2, con);
                        cmd.Parameters.AddWithValue("@mid", Id);
                        cmd.Parameters.AddWithValue("@mduration", mDuration);
                        try
                        {
                            con.Open();
                            int result = cmd.ExecuteNonQuery(); //because we are not executing the query
                            if (result > 0)
                                Console.WriteLine("movie updated");
                            else
                                Console.WriteLine("no not done");

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            con.Close();
                        }

                        break;
                    default:
                        Console.WriteLine("INVALID CHOICE");
                        break;
                }
            } while (choice!= 3);
        }
        void PrintMenu()
        {
            int choice = 0;
            Program program = new Program();
            do
            {
                Console.WriteLine("1.ADD A MOVIE");
                Console.WriteLine("2.UPDATE A MOVIE");
                Console.WriteLine("3.DELETE A MOVIE");
                Console.WriteLine("4.PRINT MOVIE BY ID");
                Console.WriteLine("5.PRINT ALL MOVIES");
                Console.WriteLine("6.SORT THE MOVIES BY DURATION");
                Console.WriteLine("7.UPDATE MOVIE BY CHOICE");
                Console.WriteLine("8.EXIT");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        program.AddMovie();
                        break;
                    case 2:
                        program.UpdateMovie();
                        break;
                    case 3:
                        program.DeleteMovie();
                        break;
                    case 4:
                        program.FetchOneMovieFromDatabase();
                        break;
                    case 5:
                        program.FetchMoviesFromDatabase();
                        break;
                    case 6:
                        program.SortMovies();
                        break;
                    case 7:
                        program.UpdateMovieChoice();
                        break;
                    default:
                        Console.WriteLine("INVALID CHOICE");
                        break;
                }
            } while (choice != 8);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program program = new Program();
            //program.AddMovie();
            //program.UpdateMovie();
            //program.DeleteMovie();
            //program.FetchMoviesFromDatabase();
            //program.CountAuthorId();
            program.PrintMenu();
            Console.ReadKey();

        }
    }
}
