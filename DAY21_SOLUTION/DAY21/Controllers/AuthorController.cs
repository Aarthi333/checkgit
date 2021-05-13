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

//[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

//[assembly: Guid("ae37abbc-83c8-4f3d-9923-33132c6eb108")]
namespace DAY21.Controllers
{
    public class AuthorController : Controller
    {
        private ILogger<AuthorController> _logger;
        private IRepo<Author> _repo;

        public AuthorController(IRepo<Author> repo,ILogger<AuthorController> logger)
        {
            _logger = logger;
            _repo = repo;            
        }
        public IActionResult Index()
        {
            List<Author> authors = _repo.GetAll().ToList();
            return View(authors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            _repo.Add(author);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Author author = _repo.Get(id);
            return View(author);
        }
        [HttpPost]
        public IActionResult Edit(int id,Author author)
        {
            _repo.Update(id,author);
            return RedirectToAction("Index");
        }
       
        public IActionResult Delete(Author author)
        {
            _repo.Delete(author);
            return RedirectToAction("Index");
        }
    }
}


