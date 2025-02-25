
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _23_02_2025.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.IdentityModel.Tokens;

namespace _23_02_2025.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly MyDbContext _context;


        public DepartmentController(MyDbContext context)
        {
            _context = context;
        }


        // GET: Department
        public IActionResult Index()
        {
            return View(_context.Departments.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Dispaly()
        {
            return View();
        }

        //public IActionResult Update( int id)
        //{
        //    var employee = _context.Departments.Find(id);
        //    return View(employee);
        //}


        //[HttpPost]
        //public IActionResult Update(Department employee)
        //{
        //    _context.Update(employee);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, string firstName, string lastName, string email, string phoneNumber)
        {
            var employee = _context.Departments.Find(id);


            if (employee == null)
            {
                return NotFound(); 
            }

            
            if (!string.IsNullOrEmpty(firstName))
            {
                employee.FirstName = firstName;
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                employee.LastName = lastName;
            }

            if (!string.IsNullOrEmpty(email))
            {
                employee.Email = email;
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                employee.PhoneNumber = phoneNumber;
            }

          
            _context.SaveChanges();

            
            return View(employee);
        }



        [HttpGet]
        public IActionResult Display(int Id)
        {
            var employee = _context.Departments.Find(Id);
          
            return View(employee);
        }


        [HttpPost]
        public IActionResult Delete(int Id )
        {
            var employee = _context.Departments.Find(Id);
            _context.Departments.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        
        }
       
    

        [HttpPost]
        public IActionResult Create(Department employee)
        {
            var departments = _context.Departments.ToList();


            for (int i=0;i< departments.Count; i++)
            {
                if(employee.FirstName.IsNullOrEmpty() || employee.LastName.IsNullOrEmpty() || employee.Email.IsNullOrEmpty() || employee.PhoneNumber.IsNullOrEmpty())
                {
                    @TempData["Message"] = "All fields are required";
                    return View(employee);
                }


                else if (employee.Email == departments[i].Email)
                {
                    @TempData["Message"] = "invalid Email! It is already exist";
                    return View(employee);
                }
                else if (employee.PhoneNumber == departments[i].PhoneNumber)
                {
                    @TempData["Message"] = "invalid PhoneNumber! It is already exist";
                    return View(employee);
                }

            }
            _context.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
