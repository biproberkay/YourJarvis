using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YourJarvis.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MerhabaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}