using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using day_22_activity.Models;
using day_22_activity.Services;
using Microsoft.Extensions.Logging;
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
//[assembly: Guid("61dcefc5-3710-40e5-9a64-523659eef9fc")]
namespace day_22_activity.Services
{
    public class EmployeeManager : IRepo<Employee>
    {
        private UserContext _context;
        private ILogger<EmployeeManager> _logger;

        public EmployeeManager(UserContext context, ILogger<EmployeeManager> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Register(Employee t)
        {
            try
            {
                _context.Employees.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
                return false;
            }
        }
        public Employee Get(int id)
        {
            try
            {
                Employee employee = _context.Employees.FirstOrDefault(a => a.Emp_Id == id);
                return employee;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                if (_context.Employees.Count() == 0)
                    return null;
                return _context.Employees.ToList();
                    //.Include(a => a.Salaries)
                    //.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }
        public bool Login(Employee t)
        {
            try
            {
                Employee employee = _context.Employees.SingleOrDefault(u => u.EmployeeName == t.EmployeeName);
                //if (employee.UserName == t.UserName)
                    Console.WriteLine("SALARY:42000,1,20/7/2012");
                      return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        //public void Login_(Employee t)
        //{

        //        Employee employee = _context.Employees.SingleOrDefault(u => u.EmployeeName == t.EmployeeName);
        //        if (employee.UserName == t.UserName)
        //               _context.Salaries.ToList();
        //}


    }
}