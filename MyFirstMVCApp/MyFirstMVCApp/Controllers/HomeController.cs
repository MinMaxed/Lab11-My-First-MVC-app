﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //display search results page
        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            return View();
        }
    }
}