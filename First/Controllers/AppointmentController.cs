﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();


        }

        public IActionResult Details(int id)
        {
            return Ok("The entered id was" + id);
        }
    }
}
