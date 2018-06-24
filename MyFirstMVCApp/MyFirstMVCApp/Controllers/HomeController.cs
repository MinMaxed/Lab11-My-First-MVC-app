using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstMVCApp.Models;


namespace MyFirstMVCApp.Controllers
{
    public class HomeController : Controller
    {

        ///display home page
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //display search results page, redirects to Resuilts to stay within single-page-application
        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            return RedirectToAction("Results", new{startYear, endYear});
        }


        //shows results based on above
        public IActionResult Results(int startYear, int endYear)
        {
            TimePerson Person = new TimePerson();

            return View( Person.GetPersons(startYear, endYear));
        }
    }
}
