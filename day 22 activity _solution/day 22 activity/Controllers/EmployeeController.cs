using System.Runtime.InteropServices;
using day_22_activity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using day_22_activity.Services;
// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

//[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

//[assembly: Guid("3b8a482b-2ecc-49aa-9c7a-05d2978a1c77")]
namespace day_22_activity.Controllers
{
    public class EmployeeController : Controller
    {
        private ILogger<EmployeeController> _logger;
        private IRepo<Employee> _repo;
        public EmployeeController(IRepo<Employee> repo, ILogger<EmployeeController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<Employee> employees = _repo.GetAll().ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            try
            {
                _repo.Register(employee);
                TempData["un"] = employee.EmployeeName;
                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Login()
        {
            //if (TempData.Count == 0)
                //return View();
            //Employee employee = new Employee();
            //employee.EmployeeName = TempData.Peek("un").ToString();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Employee employee)
        {
            try
            {
                if (_repo.Login(employee))
                   // _repo.Login(employee);
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            return View();
        }
    }
}