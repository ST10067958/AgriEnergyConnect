using AgriEnergyConnect.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgriEnergyConnect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");

            if (role == "Farmer")
                return RedirectToAction("Dashboard", "Farmer");
            else if (role == "Employee")
                return RedirectToAction("Dashboard", "Employee");
            else
                return RedirectToAction("Login", "Account");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
