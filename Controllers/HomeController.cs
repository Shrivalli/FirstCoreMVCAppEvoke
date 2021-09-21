using FirstCoreMVCApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }

        public IActionResult msg()
        {
            return Content("Welcome to my page");
        }

        public EmptyResult initialize()
        {
            ViewBag.i = 10;
            ViewBag.j = 20;
            return new EmptyResult();
        }
        
        [HttpGet]
        public ViewResult Sample()
        
        {
            initialize();
           // string Fruit = "Apple";
            ViewBag.Fruit = "Cherry";
            TempData["Fruit"] = "Banana";
            HttpContext.Session.SetString("UserName","Harry");
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            ViewBag.Name = HttpContext.Session.GetString("UserName");
            return View();
        }

        [HttpPost]
       [ActionName("Privacy")]
        public IActionResult Privacy(IFormCollection f)
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
