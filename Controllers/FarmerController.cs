using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace AgriEnergyConnect.Controllers
{
    public class FarmerController : Controller
    {
        private readonly AppDbContext _context;

        public FarmerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

            if (user == null || user.Role != "Farmer")
                return RedirectToAction("Login", "Account");

            var products = _context.Products
                .Where(p => p.FarmerId == user.FarmerId)
                .ToList();

            ViewBag.Username = user.Username;
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

            if (user == null || user.Role != "Farmer")
                return RedirectToAction("Login", "Account");

            product.FarmerId = user.FarmerId ?? 0;
            product.ProductionDate = product.ProductionDate.ToLocalTime();

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }
    }
}
