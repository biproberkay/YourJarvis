using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourJarvis.ApplicationCore.Entities;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;
using YourJarvis.ApplicationCore.ServiceInterfaces;

namespace YourJarvis.WebUI.Controllers
{
    public class ReadController : Controller
    {
        private IServiceRepository<Alan> _alanService;
        private IServiceRepository<Article> _articleService; 

        public ReadController(IServiceRepository<Alan> alanService, IServiceRepository<Article> articleService)
        {
            _alanService = alanService;
            _articleService = articleService;
        }
        public IActionResult AlanIndex() 
        {
            return View(_alanService.GetAll());
        }
        public IActionResult ArticleIndex() 
        {
            return View(_articleService.GetAll());
        }
    }
}