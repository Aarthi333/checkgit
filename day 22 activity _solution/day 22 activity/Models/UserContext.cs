using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

//[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

//[assembly: Guid("cedba2cb-3a49-4185-bd24-9ee7266d074b")]

namespace day_22_activity.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { Id=1, UserName = "Ramu", Password = "123" });

            modelBuilder.Entity<Employee>().HasData(
               new Employee() { Emp_Id = 1, EmployeeName = "hem", UserName = "Ramu", Age = 42 });
            modelBuilder.Entity<Salary>().HasData(
                new Salary() { Salary_Id = 100, salary_ = 42000, date = "20/7/2012", Emp_Id = 1 });
        }
       

    }
}

