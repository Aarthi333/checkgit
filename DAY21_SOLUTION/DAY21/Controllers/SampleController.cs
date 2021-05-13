using System.Runtime.InteropServices;
using DAY21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAY21.Services;


// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

[assembly: Guid("7917a445-bb0e-4da8-99dc-193d7046e19f")]

namespace DAY21.Controllers
{
    public class SampleController : Controller
    {
        private ISample _service;
        public SampleController(ISample service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            ViewBag.Message = _service.Check();
            return View();
        }

      
    }
}

