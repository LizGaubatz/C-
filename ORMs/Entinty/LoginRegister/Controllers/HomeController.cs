using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoginRegister.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginRegister.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User NewUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(e => e.Email == NewUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                } else {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("LoggedInUser", NewUser.UserId);
                    return RedirectToAction("LoggedIn");
                }
            } else {
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(Login UserLogin)
        {
            if(ModelState.IsValid)
            {
                User userInDb = _context.Users.FirstOrDefault(e => e.Email == UserLogin.Email);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LEmail", "Invalid login attempt");
                    return View("Index");
                }
                PasswordHasher<Login> Hasher = new PasswordHasher<Login>();
                PasswordVerificationResult result = Hasher.VerifyHashedPassword(UserLogin, userInDb.Password, UserLogin.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("Email", "Invalid login attempt");
                    return View("Index");
                } else {
                    HttpContext.Session.SetInt32("LoggedInUser", userInDb.UserId);
                    return RedirectToAction("LoggedIn");
                }
            } else {
                return View("Index");
            }
        }

        [HttpGet("LoggedIn")]
        public IActionResult LoggedIn()
        {
            int? loggedIn = HttpContext.Session.GetInt32("LoggedInUser");
            if(loggedIn != null)
            {
                ViewBag.User = _context.Users.FirstOrDefault(a => a.UserId == (int)loggedIn);
                return View();
            } else {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}