using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Womens"))
                .ToList();

            ViewBag.HockeyLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Hockey"))
                .ToList();

            ViewBag.FootballLeagues =_context.Leagues
                .Where(l => l.Sport != "Football" )
                .ToList();
            
            ViewBag.ConferenceLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();
            
            ViewBag.AtlanticLeagues =_context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();

            ViewBag.DallasLeagues =_context.Teams
                .Where(l => l.Location.Contains("Dallas"))
                .ToList();

            ViewBag.RaptorsLeagues =_context.Teams
                .Where(l => l.TeamName.Contains("Raptors"))
                .ToList();

            ViewBag.CityLeagues =_context.Teams
                .Where(l => l.Location.Contains("City"))
                .ToList();

            ViewBag.TLeagues = _context.Teams 
                .Where(l => l.TeamName.StartsWith("T"))
                .ToList();

            ViewBag.AlphaLeagues =_context.Teams
                .OrderBy(l => l.Location).ToList();

            ViewBag.ReverseLeagues =_context.Teams
                .OrderByDescending(l => l.TeamName).ToList();

            ViewBag.Cooper = _context.Players
                .Where(l => l.LastName.Contains("Cooper"))
                .ToList();

            ViewBag.JoshuaLeagues =_context.Players
                .Where(l => l.FirstName.Contains("Joshua"))
                .ToList();

            ViewBag.Cooper =_context.Players
                .Where(l => l.LastName == "Cooper" && l.FirstName != "Joshua" )
                .ToList();

            ViewBag.OrLeagues =_context.Players
                .Where(l => l.FirstName == "Alexander" || l.FirstName == "Wyatt" )
                .ToList();

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}