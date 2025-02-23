
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
