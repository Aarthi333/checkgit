using System;
using Microsoft.EntityFrameworkCore;
using EFCoreEg.OrgModel;
//using EFCoreEg.pubsModel;
using System.Linq;

namespace EFCoreEg
{
     class Program
    {
      
            //pubsContext db = new pubsContext(); //for pubsdatabase
        public static dbSoftTransportContext db = new dbSoftTransportContext();
        public static TblDriver dri = new TblDriver();
        public static void Main(string[] args)
        {
            //dbSoftTransportContext db = new dbSoftTransportContext();
            //var result = db.TblEmployees.ToList();
            ////Console.WriteLine("Hello World!");
            //foreach (var item in result)
            //{
            //    Console.WriteLine("ID:"+item.Id+"Name:"+item.Name);
            //
            //inserting data
            //TblDriver d1 = AcceptData();
            //InsertData(d1);
            //Console.WriteLine("record added successfully");
            //SelectData();
            //deleting data
            //Console.WriteLine("enter the DRIVER id you should delete");
            //int id = Convert.ToInt32(Console.ReadLine());
            //DeleteData(id);
            //Console.WriteLine("deleted successfully");
            //updating the data
            Console.WriteLine("enter the DRIVER id you WANT TO UPDATE");
            int id = Convert.ToInt32(Console.ReadLine());
            UpdateProduct(id);
            Console.WriteLine("UPDATED successfully");


        }

        private static void SelectData()
        {
            var result = db.TblDrivers.ToList();
            foreach (var item in result)
            {
                Console.WriteLine( "Name:" + item.Name + "PHONE:"+item.Phone+"STATUS:"+item.Status);
            }
        }
        private static void InsertData(TblDriver d1)
        {
            db.TblDrivers.Add(d1);
            db.SaveChanges();
        }
        private static TblDriver AcceptData()
        {
            Console.WriteLine("enter name , phone ,status ");
            dri.Name = Console.ReadLine();
            dri.Phone = Console.ReadLine();
            dri.Status = Console.ReadLine();
            return dri;
        }
        public static void DeleteData(int id)
        {
            dri = db.TblDrivers.Find(id);
            if(dri == null)
            {
                Console.WriteLine("no such employee exists");
            }
            else
            {
                db.TblDrivers.Remove(dri);
                db.SaveChanges();
                Console.WriteLine("the employee is deleted ");
            }
        }
        private static void UpdateProduct(int id)
        {
            dri = db.TblDrivers.Find(id);
            var result = db.TblDrivers.ToList(); //prints the table data 
            foreach (var item in result)
            {
                Console.WriteLine("Name:" + item.Name + "PHONE:" + item.Phone + "STATUS:" + item.Status);
            }
            dri = AcceptData(); 
            db.Update(dri);
            db.SaveChanges();
        }

    }
}
