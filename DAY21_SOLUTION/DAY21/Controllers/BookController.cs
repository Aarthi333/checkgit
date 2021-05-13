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

//[assembly: Guid("e868d2a0-e072-47f7-8ac7-e6d3e4edffee")]

namespace DAY21.Controllers
{
    public class BookController : Controller
    {
        private ILogger<BookController> _logger;
        private IRepo<Book> _repo;

        public BookController(IRepo<Book> repo, ILogger<BookController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<Book> books = _repo.GetAll().ToList();
            return View(books);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            _repo.Add(book);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Book book = _repo.Get(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            _repo.Update(id, book);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Book book)
        {
            _repo.Delete(book);
            return RedirectToAction("Index");
        }


    }
}

