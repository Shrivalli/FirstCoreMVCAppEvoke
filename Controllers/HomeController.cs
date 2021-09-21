using FirstCoreMVCApp.Models;
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
