using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace FinalE.Controllers
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
            return View();
        }


        
        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("loggedInUser", newUser.UserId);
                return RedirectToAction("Home");
            }else{
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            if(ModelState.IsValid)
            {
                User userindb = _context.Users.FirstOrDefault(u => u.Email == login.LoginEmail);
                if(userindb == null)
                {
                    ModelState.AddModelError("Login Email", "Invalid login attempt");
                    return View("Index");
                }
                PasswordHasher<Login> hasher = new PasswordHasher<Login>();
                var result = hasher.VerifyHashedPassword(login, userindb.Password, login.LoginPassword);
                if(result == 0)
                {
                    ModelState.AddModelError("Login Email", "Invalid login attempt");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("loggedInUser", userindb.UserId);
                return RedirectToAction("Home");
            }else{
                return View("Index");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet("home")]
        public IActionResult Home()
        {
            if(HttpContext.Session.GetInt32("loggedInUser") == null)
            {
                Console.WriteLine("No user logged in");
                return RedirectToAction("Index");
            }
            ViewBag.AllActivities = _context.Activities.Include(c => c.Coordinator).Include(p => p.Participants).ThenInclude(u => u.User).OrderBy(d => d.ActivityDate).ToList();
            ViewBag.LoggedInUser = _context.Users.FirstOrDefault(u => u.UserId == (int)HttpContext.Session.GetInt32("loggedInUser"));
            return View();
        }

        [HttpGet("newActivity")]
        public IActionResult NewActivity()
        {
            if(HttpContext.Session.GetInt32("loggedInUser") == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost("newActivity")]
        public IActionResult AddActivity(Activities newActivity)
        {
            if(HttpContext.Session.GetInt32("loggedInUser") == null)
            {
                return RedirectToAction("Index");
            }
            if(ModelState.IsValid)
            {
                newActivity.UserId = (int)HttpContext.Session.GetInt32("loggedInUser");
                int activityid = newActivity.ActivityId;
                _context.Add(newActivity);
                _context.SaveChanges();
                return RedirectToAction("Home");
            }else {
                return View("NewActivity");
            }
        }

        [HttpGet("activity/{activityId}")]
        public IActionResult OneActivity(int activityId)
        {
            if(HttpContext.Session.GetInt32("loggedInUser") == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.LoggedInUser = _context.Users.FirstOrDefault(u => u.UserId == (int)HttpContext.Session.GetInt32("loggedInUser"));
            Activities oneActivity = _context.Activities.Include(c => c.Coordinator).Include(p => p.Participants).ThenInclude(u => u.User).FirstOrDefault(a => a.ActivityId == activityId);
            return View(oneActivity);
        }

        [HttpGet("join/{activityId}/{userId}")]
        public IActionResult Join(int activityId, int userId)
        {
            if(HttpContext.Session.GetInt32("loggedInUser") == null)
            {
                return RedirectToAction("Index");
            }
            if(HttpContext.Session.GetInt32("loggedInUser") != userId)
            {
                return RedirectToAction("Logout");
            }
            Participants participate = new Participants();
            participate.ActivityId = activityId;
            participate.UserId = userId;
            _context.Add(participate);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpGet("leave/{activityId}/{userId}")]
        public IActionResult Leave(int activityId, int userId)
        {
            if(HttpContext.Session.GetInt32("loggedInUser") == null)
            {
                return RedirectToAction("Index");
            }
            if(HttpContext.Session.GetInt32("loggedInUser") != userId)
            {
                return RedirectToAction("Logout");
            }
            Participants ParticipantsToRemove = _context.Participants.FirstOrDefault(a => a.ActivityId == activityId && a.UserId == userId);
            _context.Participants.Remove(ParticipantsToRemove);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpGet("delete/{ActivityId}")]
        public IActionResult Delete(int ActivityId)
        {
            Activities DeleteActivity = _context.Activities.FirstOrDefault(p => p.ActivityId == ActivityId);
            if(HttpContext.Session.GetInt32("loggedInUser") != DeleteActivity.UserId)
            {
                return RedirectToAction("Logout");
            }
            _context.Activities.Remove(DeleteActivity);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}