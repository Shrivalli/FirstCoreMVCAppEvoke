using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreMVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection f)
        {
            string uname = f["uname"].ToString();
            HttpContext.Session.SetString("Username", uname);
            string password = f["pwd"].ToString();
            if((uname.Equals("admin")) && (password.Equals("welcome")))
            {
                return RedirectToAction("Dashboard");
            }
            else
            return View();
        }

        public IActionResult Dashboard()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            if (ViewBag.Username != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
