using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace ExploreDb
{
    class Program
    {
        public void InsertBooks()
        {
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            //SqlCommand cmd = new SqlCommand("insert into tbl_books values('HarryPotter',3,950)", con);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into tbl_books values('Two states',1,650)";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //method 1 for stored procedure
        //public string BookSp(string title,int aid,double price)
        //{
        //    string res = null;
        //    SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
        //    SqlCommand cmd = new SqlCommand("sp_InsBook", con);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
        //    cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
        //    cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    res = "success";
        //    return res;
        //}
        //method 2 for stored procedure
        public string BookSp(string title, int aid, double price)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            SqlCommand cmd = new SqlCommand("sp_InsBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@Title";
            p1.SqlDbType = SqlDbType.VarChar;
            p1.Value = title;
            cmd.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "AuthorID";
            p2.SqlDbType = SqlDbType.Int;
            p2.Value = aid;
            cmd.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@Price";
            p3.SqlDbType = SqlDbType.Money;
            p3.Value = price;
            cmd.Parameters.Add(p3);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "success";
            return res;
        }
        public string UpdtBookSp(string title, double price)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            SqlCommand cmd = new SqlCommand("sp_UpdBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "success";
            return res;
        }
        public string DeleteBookSp(int bookid)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            SqlCommand cmd = new SqlCommand("sp_DelBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookId", SqlDbType.Int).Value = bookid;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "success";
            return res;
        }

        public void UpdatBook()
        {
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            string qry = "update tbl_books set Title = @Title where BookId = 1006";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Title", "Davinci Code");
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteBook()
        {
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            string qry = "delete from tbl_books where BookId = 1008";
            SqlCommand cmd = new SqlCommand(qry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void SelectAuthor()
        {
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            string qry = "select * from tbl_author";
            SqlCommand cmd = new SqlCommand(qry, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                Console.WriteLine(rdr["AuthorID"] + " " + rdr["AuthorName"].ToString());
            con.Close();
        }
        public void InsertAuthor()
        {
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            //SqlCommand cmd = new SqlCommand("insert into tbl_books values('HarryPotter',3,950)", con);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into tbl_author values('vishwanathan anand')";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string UpdAuthorSp(int authorid,string authorname)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            SqlCommand cmd = new SqlCommand("sp_UpdAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.NVarChar).Value =authorid;
            cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.Money).Value = authorname;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "success";
            return res;
        }
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            //strConnection = @"server=LAPTOP-V7NNEK9K;Integrated security= true ; Initial catalog = dbSoftTransport";
            SqlCommand cmd = new SqlCommand("select * from tbl_books", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                Console.WriteLine(rdr["BookId"] + " " + rdr["Title"]+" "+rdr["Price"].ToString());
            con.Close();
            Program obj = new Program();
            //obj.InsertBooks();
            //obj.UpdatBook();
            //obj.DeleteBook();
            //obj.BookSp("shutter island", 4, 550);
            //obj.UpdtBookSp("mindmaster", 750);
            //obj.DeleteBookSp(1006);
            //obj.SelectAuthor();
            //obj.InsertAuthor();
            obj.UpdAuthorSp(8, "Dennis Lehane");
            Console.ReadLine();
        }
    }
}
