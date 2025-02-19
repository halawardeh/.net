using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication11111.Models;

namespace WebApplication11111.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
      
    }
}
