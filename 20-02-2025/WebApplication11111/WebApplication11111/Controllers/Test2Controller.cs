using Microsoft.AspNetCore.Mvc;

namespace WebApplication11111.Controllers
{
    public class Test2Controller : Controller
    {
        public IActionResult Index()
        {
            ViewData["Msg"] = "this is view data example";
            ViewBag.Welcom = "this is view bag example";
            int[] grads = { 1, 2, 3 };
            ViewBag.classgrads = grads;
            TempData["TempModel"] = "This is TempData Example";
            return RedirectToAction("TempDataEx");
            //return View();
        }
        public ActionResult TempDataEx()
        {

            return RedirectToAction("about","Home");
        }

        public ActionResult handlePrivacy()
        {
            return RedirectToAction("about" , "Home");
        }

    }
}
