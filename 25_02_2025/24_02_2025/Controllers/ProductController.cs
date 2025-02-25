using Microsoft.AspNetCore.Mvc;
using _24_02_2025.Models;
using Microsoft.IdentityModel.Tokens;

namespace _24_02_2025.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyDbContext _context;


        public ProductController(MyDbContext context)
        {
            _context = context;
        }


        // GET: product
        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Display()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, string Name, decimal Price, string Description, string Image)
        {
            var product = _context.Products.Find(id);


            if (product == null)
            {
                return NotFound();
            }


            if (!string.IsNullOrEmpty(Name))
            {
                product.Name = Name;
            }

            if (Price!=0)
            {
                product.Price = Price;
            }

            if (!string.IsNullOrEmpty(Description))
            {
                product.Description = Description;
            }

            if (!string.IsNullOrEmpty(Image))
            {
                product.Image = Image;
            }


            _context.SaveChanges();


            return View(product);
        }



        [HttpGet]
        public IActionResult Display(int Id)
        {
            var product = _context.Products.Find(Id);

            return View(product);
        }


        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var product = _context.Products.Find(Id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }



        [HttpPost]
        public IActionResult Create(Product product)
        {
           
            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
