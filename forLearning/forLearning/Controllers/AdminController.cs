using Microsoft.AspNetCore.Mvc;

namespace ForLearning.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}
