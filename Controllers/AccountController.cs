// ---------------------------------------------------------------------------
// Title       : Java regex validate password examples
// Adapted by  : Keagan Shaw (ST10067958) for ASP.NET Core
// Original Author : Mkyong
// Date        : 5 November 2020
// Code Version: 1
// URL         : https://mkyong.com/regular-expressions/how-to-validate-password-with-regular-expression/
// Description : This controller uses password validation logic adapted from Mkyong’s regex examples.
// Usage       : For educational purposes – adapted to C# validation in Agri-Energy Connect.
// ---------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnect.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // Save user info in session
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("Role", user.Role);
                HttpContext.Session.SetInt32("UserId", user.UserId);

                if (user.Role == "Farmer")
                    return RedirectToAction("Dashboard", "Farmer");
                else
                    return RedirectToAction("Dashboard", "Employee");
            }

            ViewBag.Error = "Invalid login credentials";
            return View();
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (user.Role == "Farmer")
                    {
                        // Create a dummy farmer profile (you can improve this later)
                        var farmer = new Farmer
                        {
                            Name = user.Username, // or ask for it on the form
                            Email = user.Username + "@example.com",
                            Location = "Unknown"
                        };

                        _context.Farmers.Add(farmer);
                        _context.SaveChanges();

                        user.FarmerId = farmer.FarmerId;
                    }

                    _context.Users.Add(user);
                    _context.SaveChanges();

                    return RedirectToAction("Login");
                }
                catch (DbUpdateException ex)
                {
                    ViewBag.Error = ex.InnerException?.Message ?? ex.Message;
                }
            }

            ViewBag.ModelErrors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return View(user);
        }




        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
