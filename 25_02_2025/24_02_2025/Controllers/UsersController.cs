using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _24_02_2025.Models;

namespace _24_02_2025.Controllers
{
    public class UsersController : Controller
    {
        private readonly MyDbContext _context;
        public const string SessionKeyName = "Email";
        public const string SessionKeyAge = "Password";
        public UsersController(MyDbContext context)
        {
            _context = context;
        }

      
        // GET: UserController
        public ActionResult Index()
        {
            var allUsers = _context.Users.ToList();

            return View(allUsers);
        }


        // GET: UserController/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: UserController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {

            if (ModelState.IsValid)
            {
                user.Role = "user";
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(user);
                //return Unauthorized();
            }

        }



        // GET: UserController/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: UserController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HandelLogin(User user)
        {

            if (ModelState.IsValid)
            {
                var userInfo = _context.Users.FirstOrDefault(u => u.Email == user.Email &&  u.Password == user.Password   );

                if (userInfo.Role == "user")
                {
                    HttpContext.Session.SetString("Name", user.Name);
                    HttpContext.Session.SetString("Email", user.Email);
                    HttpContext.Session.SetString("Password", user.Password);
                    HttpContext.Session.SetString("Role", user.Role);
                    return RedirectToAction(nameof(Index));
                   
                }
                else
                {
                    return RedirectToAction(nameof(Login));

                }
            }
            else
            {
                return View(user);

            }

        }

        public IActionResult Profile()
        {
            ViewData["Name"] = HttpContext.Session.GetString("Name");
            ViewData["Email"] = HttpContext.Session.GetString("Email");

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Users");
        }



        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var UserDetails = _context.Users.Find(id);
            return View(UserDetails);
        }



        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }



        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
