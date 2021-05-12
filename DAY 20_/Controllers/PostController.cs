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

//[assembly: Guid("faca8df0-1158-4c69-bda7-75090b8b7a41")]

namespace DAY_20.Controllers
{
    public class PostController : Controller
    {

        //private readonly ILogger<HomeController> _logger;

        //public IActionResult Index()
        //{
        //    return View();
        //}
        static List<Post> posts = new List<Post>()
            {
                new Post() { Id= 101,PostText="check the status of movies on may 14",Category="film"},
                new Post() { Id = 102, PostText = "always wash hands with soap", Category = "health" },
                new Post() { Id = 103, PostText = "new arrivals ...rose milk and badam milk", Category = "food" }
            };

        public IActionResult Index()
        {
            return View(posts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            posts.Add(post);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            int idx = posts.FindIndex(p => p.Id == id);
            return View(posts[idx]);
        }
        [HttpPost]
            public IActionResult Edit(int id,Post post)
        {
            int idx = posts.FindIndex(p => p.Id == id);
            posts[idx].PostText = post.PostText;
            posts[idx].Category = post.Category;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            int idx = posts.FindIndex(p => p.Id == id);
            return View(posts[idx]);
        }
        [HttpPost]
        public IActionResult Delete(int id, Post post)
        {
            int idx = posts.FindIndex(p => p.Id == id);
            //posts[idx].PostText = post.PostText;
            //posts[idx].Category = post.Category;
            posts.RemoveAt(idx);
            return RedirectToAction("Index");
        }

    }
}

