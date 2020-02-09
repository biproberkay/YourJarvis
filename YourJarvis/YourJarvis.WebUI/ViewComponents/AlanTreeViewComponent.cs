using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourJarvis.ApplicationCore.Entities;
using YourJarvis.ApplicationCore.ServiceInterfaces;

namespace YourJarvis.WebUI.ViewComponents
{
    public class AlanTreeViewComponent : ViewComponent
    {
        private IServiceRepository<Alan> _alanService;

        public AlanTreeViewComponent(IServiceRepository<Alan> alanService)
        {
            _alanService = alanService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_alanService.GetAll());
        }
    }
}
