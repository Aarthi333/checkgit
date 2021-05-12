using DAY_20.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DAY_20.Controllers
{
    public class HomeController : Controller
    {
        int[] arr = { 12, 34, 5, 6, 89, 56, 90 };
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {

            ViewData["Name"] = "Ramu";
            ViewData["Age"] = 21;
            ViewBag.CustomerPhone = "76490756";
            ViewBag.Price = 123.42;
            TempData["Post"] = "this is the post that i want to post";
            var numbers = arr.Where(num => num < 75);
            ViewData["scores"] = numbers;
            ViewBag.Scores = numbers;
            return View();
        }
        public IActionResult About()
        {

            //ViewData["Name"] = "Ramu";
            //ViewData["Age"] = 21;
            //ViewBag.CustomerPhone = "76490756";
            //ViewBag.Price = 123.42;
            //TempData["Post"] = "this is the post that i want to post";
            //var numbers = arr.Where(num => num < 75);
            //ViewData["scores"] = numbers;
            //ViewBag.Scores = numbers;
            TempData["Post"] = "this is the post that i want to post";
            return View();
        }
        public IActionResult ShowPost()
        {
            Post post = new Post();
            post.Id = 101;
            post.PostText = "check this out.text post";
            post.Category = "ref";
            return View(post);
        }
        


            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public string Index()
        //{
        //    return "Hello from controller";
        //}
    }
}
