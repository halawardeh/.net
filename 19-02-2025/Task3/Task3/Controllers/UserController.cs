using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Task3.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            ViewData["Name"] = HttpContext.Session.GetString("Name");
            ViewData["Email"] = HttpContext.Session.GetString("Email");

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult HandleLogin(string email, string password, string rem)
        {

            string email1 = HttpContext.Session.GetString("Email");
            string password1 = HttpContext.Session.GetString("Password");
            string rem1 = HttpContext.Session.GetString("rem");

            if (string.IsNullOrEmpty(email1) || string.IsNullOrEmpty(password)) 
            {
                TempData["Message"] = "Please Fill All Feilds!";
                return RedirectToAction("Login");
            }
            else
            {
                if (email1 == email && password1 == password)
                {
                    if (rem1 != null)
                    {
                        CookieOptions obj = new CookieOptions();
                        obj.Expires = DateTime.Now.AddDays(7);
                        //store
                        Response.Cookies.Append("userInfo", email, obj);
                    }
                    TempData["User"] = new string[] { email, password };
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Message"] = "Wrong email or password!";
                    return RedirectToAction("Login");
                }
            }
        }

        [HttpPost]
        public IActionResult HandleRegister(string name, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name)
                || string.IsNullOrEmpty(confirmPassword))
            {
                TempData["Message"] = "Please Fill All Feilds!";
                return RedirectToAction("Register");
            }
            else
            {
                if (confirmPassword == password)
                {
                    HttpContext.Session.SetString("Name", name);
                    HttpContext.Session.SetString("Email", email);
                    HttpContext.Session.SetString("Password", password);
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["Message"] = "Password Does Not Match";
                    return RedirectToAction("Register");
                }
            }

        }
    }
}
