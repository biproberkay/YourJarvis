using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourJarvis.ApplicationCore.Entities;
using YourJarvis.ApplicationCore.ServiceInterfaces;

namespace YourJarvis.WebUI.Controllers
{
    public class ReadController : Controller
    {
        private IServiceRepository<Alan> _alanService;

        public ReadController(IServiceRepository<Alan> alanService)
        {
            _alanService = alanService;
        }
        public IActionResult AlanIndex() 
        {
            return View(_alanService.GetAll());
        }
    }
}