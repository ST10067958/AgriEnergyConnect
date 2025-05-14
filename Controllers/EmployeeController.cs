﻿using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AgriEnergyConnect.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "Employee")
                return RedirectToAction("Login", "Account");

            ViewBag.Farmers = _context.Farmers.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult AddFarmer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFarmer(Farmer farmer)
        {
            if (!ModelState.IsValid)
            {
                return View(farmer); 
            }

            _context.Farmers.Add(farmer);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }


        [HttpGet]
        public IActionResult ViewProducts(int? farmerId, string category, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Products.Include(p => p.Farmer).AsQueryable();

            if (farmerId != null)
                query = query.Where(p => p.FarmerId == farmerId);

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category == category);

            if (startDate.HasValue)
                query = query.Where(p => p.ProductionDate >= startDate);

            if (endDate.HasValue)
                query = query.Where(p => p.ProductionDate <= endDate);

            var result = query.ToList();

            ViewBag.Farmers = _context.Farmers.ToList();
            return View(result);
        }
    }
}
