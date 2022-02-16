using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DojoSurvey.Models;

namespace DojoSurvey.Controllers
{
    public class HomeController : Controller
    {
        static Survey newSurvey;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost ("submit")]
        public IActionResult Submit(Survey survey)
        {
            if(ModelState.IsValid)
            {    
                newSurvey = survey;
                return RedirectToAction("SurveyResponse", newSurvey);
            }
            else
            {
                Console.WriteLine("Response Error");
                return View("Index");
            }
        }

        [HttpGet("SurveyResponse")]
        public IActionResult SurveyResponse()
        {
            return View(newSurvey);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}