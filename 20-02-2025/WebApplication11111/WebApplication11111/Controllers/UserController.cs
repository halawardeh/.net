using Microsoft.AspNetCore.Mvc;

namespace WebApplication11111.Controllers
{
    public class UserController : Controller
    {

    public const string SessionKeyName = "_Email";
    public const string SessionKeyAge = "_Password";

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, "The Doctor");
                HttpContext.Session.SetInt32(SessionKeyAge, 73);
            }
            var userEmail = HttpContext.Session.GetString(SessionKeyName);
            var userPassword = HttpContext.Session.GetString(SessionKeyAge);

            _logger.LogInformation("Session email: {_Email}", userEmail);
            _logger.LogInformation("Session password: {_Password}", userPassword);
     }


        [HttpPost]
        public IActionResult HandelLogin(string email, string password)
        {
    


            string Email = email;
            string Password = password;
            if (Email == "admin@gmail.com" && password == "123")
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                TempData["ErrorMesage"] = "Wrong user name or password";
                return RedirectToAction("Login");
            }
        }

        public IActionResult HandelRegister(string name ,string email, string password)
        {

            string Name = name;
            string Email = email;
            string Password = password;
            return RedirectToAction("Register");

        }
        public IActionResult HandelProfile()
        {
            string Email = @HttpContext.Session.GetString("_Email"); 
            string Password = @HttpContext.Session.GetString("_Password");

            return RedirectToAction("Profile");

        }
        public IActionResult Login()
        {


            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
