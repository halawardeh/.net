using System.Diagnostics;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Task3.Models;

namespace Task3.Controllers
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
            string name = HttpContext.Session.GetString("Name");
            ViewBag.Name = name;

            string email = HttpContext.Session.GetString("Email");
            ViewBag.Email = email;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult cookies()
        {
          
            Response.Cookies.Append("name", "hala");
            ViewBag.name= Request.Cookies["name"];

            return View();
        }

    }
}


