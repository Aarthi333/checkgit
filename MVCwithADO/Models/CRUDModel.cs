using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace MVCwithADO.Models
{
    public class CRUDModel
    {
        public DataTable DisplayBook()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            //SqlCommand cmd = new SqlCommand("select BookId,Title,AuthorID,Price from tbl_Books ", con);
            SqlCommand cmd = new SqlCommand("select BookId,Title,AuthorName,Price  from tbl_Books b join tbl_author a on b.AuthorID = a.AuthorID ", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int NewBookSp(string title,int aid, double price)
        {
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@AuthorID", aid);
            cmd.Parameters.AddWithValue("@Price", price);
            return cmd.ExecuteNonQuery();
            con.Close();          
        }
        public int EditBookSp(string title, double price)
        {
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_UpdBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;           
            return cmd.ExecuteNonQuery();
            con.Close();
        }
        //another method for update without sp
        public DataTable BookById(int bookid)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from  tbl_Books where BookId = " +bookid, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int UpdateBook(int Bid , string title,int aid,double price)
        {
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            con.Open();
            SqlCommand cmd = new SqlCommand("update tbl_Books set Title = @title ,AuthorID= @aid,Price = @price  where BookId = @bid", con);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@aid", aid);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@bid",Bid);
            return cmd.ExecuteNonQuery();
            con.Close();
        }
        public int DeleteBook(int bookid)
        {
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_Books where BookId = @bkid", con);
            cmd.Parameters.AddWithValue("@bkid", bookid);
            return cmd.ExecuteNonQuery();
            con.Close();
        }

        //author
        public DataTable DisplayAuthor()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            SqlCommand cmd = new SqlCommand("select AuthorID,AuthorName from tbl_author", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int NewAuthorSp(string aname)
        {
            SqlConnection con = new SqlConnection("data source = LAPTOP-V7NNEK9K ;Integrated security= true ; database= BooksDb;  ");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsAuthor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", aname);
            return cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}