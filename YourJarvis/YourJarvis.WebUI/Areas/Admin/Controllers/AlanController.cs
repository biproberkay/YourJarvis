﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YourJarvis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}