using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;


        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.allProducts = _context.Products.OrderBy(a => a.ProductName).ToList();
            return View();
        }

        [HttpPost("NewProduct")]
        public IActionResult NewProduct(Product NewProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(NewProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.allProducts = _context.Products.OrderBy(a => a.ProductName).ToList();
                return View("Index");
            }
        }


        [HttpGet("Categories")]
        public IActionResult Categories()
        {
            ViewBag.allCategories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View();
        }


        [HttpPost("NewCategory")]
        public IActionResult NewCategory(Category NewCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(NewCategory);
                _context.SaveChanges();
                return RedirectToAction("categories");
            }
            else
            {
                ViewBag.allCategories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
                return View("Categories");
            }
        }


        [HttpGet("Product/{ProductId}")]
        public IActionResult oneProduct(int ProductId)
        {
            Product one = _context.Products.Include(f => f.Associations).ThenInclude(g => g.Category).FirstOrDefault(p => p.ProductId == ProductId);
            ViewBag.allCategories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(one);
        }


        [HttpPost("/product/newProdToCat")]
        public IActionResult newProdToCat(Association newProdToCat)
        {
            _context.Add(newProdToCat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet("Category/{CategoryId}")]
        public IActionResult oneCategory(int CategoryId)
        {
            Category one = _context.Categories.Include(f => f.Associations).ThenInclude(g => g.Product).FirstOrDefault(p => p.CategoryId == CategoryId);
            ViewBag.allProducts = _context.Products.OrderBy(p => p.ProductName).ToList();
            return View(one);
        }


        [HttpPost("/category/newCatToProd")]
        public IActionResult newCatToProd(Association newCatToProd)
        {
            _context.Add(newCatToProd);
            _context.SaveChanges();
            return RedirectToAction("Index");
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