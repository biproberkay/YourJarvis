using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;
using YourJarvis.ApplicationCore.ServiceInterfaces;
using YourJarvis.WebUI.Areas.Admin.Models;

namespace YourJarvis.WebUI.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IActionResult ArticleList() 
        {
            var articles = _articleService.GetAll();
            return View(new ArticleListModel() { Articles = articles});
        }
        public IActionResult ArticleDetayGetir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Article article = _articleService.GetArticleDetails((int)id);
            if (article == null)
            {
                return NotFound();
            }

            return View(new ArticleDetayGetirModel()
            {
                Article = article,
                Alan = article.Alan,
                Tags = article.ArticleTags.Select(at => at.Tag).ToList()
            }); ;
        }
    }
}