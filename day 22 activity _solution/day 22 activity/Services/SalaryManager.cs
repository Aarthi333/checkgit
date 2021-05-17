using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using day_22_activity.Models;
using Microsoft.Extensions.Logging;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

//[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

//[assembly: Guid("479a4097-6e37-4ccf-9852-afa2d1596dd9")]


namespace day_22_activity.Services
{
    public class SalaryManager : IRepo<Salary>
    {
        private UserContext _context;
        private ILogger<SalaryManager> _logger;

        public SalaryManager(UserContext context, ILogger<SalaryManager> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Register(Salary t)
        {
            try
            {
                _context.Salaries.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return false;
        }
        public void Delete(Salary t)
        {
            throw new NotImplementedException();
        }

        public Salary Get(int id)
        {
            try
            {
                Salary salary = _context.Salaries.FirstOrDefault(a => a.Salary_Id == id);
                return salary;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Salary> GetAll()
        {
            try
            {
                if (_context.Salaries.Count() == 0)
                    return null;
                return _context.Salaries
                    .ToList();
            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public void Update(int id, Salary t)
        {
            throw new NotImplementedException();
        }

        public bool Login(Salary t)
        {
            try
            {
                 Salary salary = _context.Salaries.SingleOrDefault(u => u.Salary_Id == t.Salary_Id);
                if (salary.Emp_Id == t.Emp_Id)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }


    }
}
