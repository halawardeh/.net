using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace ForLearning.Controllers

{
    public class UserController : Controller
    {
    
        public IActionResult Register()
        {
      
            return View();
        }
      
        public IActionResult Login()
        {
           
            return View();
        }
   
        public IActionResult Profile()
        {

            ViewData["name"] = HttpContext.Session.GetString("name");
            ViewData["email"] = HttpContext.Session.GetString("email");
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
        public IActionResult HandleRegister(string name, string email, string password, string comfirmPass)
        {
            if (string.IsNullOrEmpty("name") || string.IsNullOrEmpty("email") || string.IsNullOrEmpty("password") || string.IsNullOrEmpty("comfirmPass"))
            {
                TempData["Message"] = "All feild are required";
                return RedirectToAction("Register");
            }
            else if (password != comfirmPass)
            {
                TempData["Message"] = "The two passwords are not matched";
                return RedirectToAction("Register");
            }
            else
            {
                HttpContext.Session.SetString("name", name);
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("password", password);
                return RedirectToAction("Login");
            }


        }
        public IActionResult HandleLogin(string email, string password)
        {
           
            var SessionEmail = HttpContext.Session.GetString("email");
            var SessionPssword = HttpContext.Session.GetString("password");
            
            if(string.IsNullOrEmpty(SessionEmail) || string.IsNullOrEmpty(SessionPssword))
            {
                TempData["Message"] = "Please fill all data";
            }
            else
            {
                if(SessionPssword == password && SessionEmail==email)
                {
                    TempData["user"] = new string[] { email, password };
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Message"] = "Invalid Email or Password";
                    return RedirectToAction("Login");

                }
            }
          
            return View();
        }
       

    }
}
