using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomPassGen.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPassGen.Controllers
{
    public class HomeController : Controller
    {
        public static int PassWordNum = 0;
        
        public IActionResult Index()
        {
            Password Word = new Password();
            ViewBag.PassWord = Word.WordPass;
            PassWordNum += 1;
            ViewBag.PassWordNum = PassWordNum;
            return View("Index");
        }

        [HttpGet("/ajax")]
        public IActionResult Ajax(){
            Console.WriteLine("Made it to the Ajax route");
            Password word = new Password();
            PassWordNum ++;
            return Json(new {password=word.WordPass,num=PassWordNum});
        }
        [HttpGet("reset")]
        public IActionResult Reset()
        {
            PassWordNum = 0;
            return View("Index", PassWordNum);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}