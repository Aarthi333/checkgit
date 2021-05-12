using System.Runtime.InteropServices;
using DAY_20.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

//[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

//[assembly: Guid("55e9ef0e-8b0f-4f56-a9ce-1588f2f2f966")]

namespace DAY_20.Controllers
{
    public class CommentController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public IActionResult Index()
        //{
        //    return View();
        //}
          static List<Comment> comments = new List<Comment>()
            {
                new Comment() { Id= 1,CommenText="MY FIRST COMMENT",PostId=101},
                new Comment() { Id = 2, CommenText="MY second COMMENT",PostId=102 },
                new Comment() { Id = 3, CommenText="MY third COMMENT",PostId=103}
            };

        public IActionResult Index()
        {
            return View(comments);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            comments.Add(comment);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            int idx = comments.FindIndex(p => p.Id == id);
            return View(comments[idx]);
        }
        [HttpPost]
        public IActionResult Edit(int id, Comment comment)
        {
            int idx = comments.FindIndex(p => p.Id == id);
            comments[idx].CommenText = comment.CommenText;           
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            int idx = comments.FindIndex(p => p.Id == id);
            return View(comments[idx]);
        }
        [HttpPost]
        public IActionResult Delete(int id, Comment comment)
        {
            int idx = comments.FindIndex(p => p.Id == id);
            //posts[idx].PostText = post.PostText;
            //posts[idx].Category = post.Category;
            comments.RemoveAt(idx);
            return RedirectToAction("Index");
        }

    }
}
