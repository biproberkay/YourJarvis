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
        private IArticleService _articleService;
        //private IAlanService _alanService;

        public ReadController(
                                IArticleService articleService
                                //, IAlanService alanService
                                )
        {
            _articleService = articleService;
            //_alanService = alanService;
        }
        public IActionResult Index()
        {
            return View(_articleService.GetAll());
        }
        public IActionResult AlanIndex() 
        {
            return
                Content("Bu iş olmadı");
            //View(_alanService.GetAll());
        }
    }
}