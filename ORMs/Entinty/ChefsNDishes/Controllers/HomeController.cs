using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(d => d.Dishes).ToList();

            return View(AllChefs);
        }

        [HttpGet("AllDishes")]
        public IActionResult AllDishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.ToList();

            ViewBag.AllChefs = dbContext.Chefs.Include(d => d.Dishes).ToList();

            return View(AllDishes);
        }

        [HttpGet("NewChef")]
        public IActionResult NewChef()
        {
            return View();
        }

        [HttpGet("NewDish")]
        public IActionResult NewDish()
        {
            ViewBag.AllChefs = dbContext.Chefs.Include(d => d.Dishes).ToList();

            return View();
        }

        [HttpPost("NewChef")]
        public IActionResult NewChef(Chef NewChef)
        {
            if (ModelState.IsValid)
            {
                // dbContext is the database
                dbContext.Chefs.Add(NewChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef");
            }
        }

        [HttpPost("NewDish")]
        public IActionResult NewDish(Dish NewDish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Dishes.Add(NewDish);
                dbContext.SaveChanges();
                return RedirectToAction("AllDishes");
            }
            else
            {
                return View("NewDish");
            }
        }
    }
}