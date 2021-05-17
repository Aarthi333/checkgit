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
//using day_22_activity.Services;
// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

//[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

//[assembly: Guid("a35bc871-33cb-434d-ab46-af7fd96699f5")]
namespace day_22_activity.Controllers
{
    public class UserController : Controller
    {
        private ILogger<UserController> _logger;
        private IRepo<User> _repo;

        public UserController(IRepo<User> repo, ILogger<UserController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        public IActionResult Index()
        {          
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            try
            {
                _repo.Register(user);
                TempData["un"] = user.UserName;
                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Login()
        {
            if (TempData.Count == 0)
                return View();
            User user = new User();
            user.UserName = TempData.Peek("un").ToString();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            try
            {
                if (_repo.Login(user))
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
