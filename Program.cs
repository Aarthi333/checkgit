using System;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstEg
{
    class Program
    {
        public static EFContext db = new EFContext();
        public static Product p = new Product();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            p = AcceptDetails();
            AddProduct(p);
            Console.WriteLine("to display...");
            DisplayProducts();
            //Console.WriteLine("to delete....");
            //Delete();
            //Console.WriteLine("to display...");
            //DisplayProducts();
            Console.WriteLine("to update...");
            Update();
            Console.WriteLine("to display...");
            DisplayProducts();
        }
        private static void DisplayProducts()
        {
            //using (var db= new EFContext()) //ANOTHER METHOD FOR CODE EFFICIENCY-TO DISPOSE MEMORY AFTER TRANSACTION
            foreach (var item in db.Products)
            {
                Console.WriteLine(item.ToString()); //overriding the to string method of product class
            }
        }
        private static void AddProduct(Product p1)
        {
            db.Products.Add(p1);
            db.SaveChanges();
            Console.WriteLine("records added ");

        }
        private static Product AcceptDetails()
        {
            Console.WriteLine("please enter product name ,price ,quantity");
            p.Name = Console.ReadLine();
            p.Price = Convert.ToInt32(Console.ReadLine());
            p.Qty = Convert.ToInt32(Console.ReadLine());
            return p;
        }

        private static void Delete()
        {
            Console.WriteLine("enter the employee id you should delete");
            int id = Convert.ToInt32(Console.ReadLine());
            DeleteData(id);
            Console.WriteLine("deleted successfully");

        }
        public static void DeleteData(int id)
        {
            p = db.Products.Find(id);
            if (p == null)
            {
                Console.WriteLine("no such product exists");
            }
            else
            {
                db.Products.Remove(p);
                db.SaveChanges();
                Console.WriteLine("the product is deleted ");
            }
        }
        private static void Update()
        {
            Console.WriteLine("enter the employee id you should update");
            int id = Convert.ToInt32(Console.ReadLine());
            UpdateProduct(id);
            Console.WriteLine("updated successfully");
        }

        private static Product GetProductById(int id)
        {
            p = db.Products.Find(id);
            return p;
        }

        private static void UpdateProduct(int id)
        {
            p = GetProductById(id);
            Console.WriteLine(p.ToString());
            p = AcceptDetails();
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }
     
    }
}
