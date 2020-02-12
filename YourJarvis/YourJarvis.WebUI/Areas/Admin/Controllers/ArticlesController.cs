using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YourJarvis.ApplicationCore.Entities;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;
using YourJarvis.ApplicationCore.ServiceInterfaces;
using YourJarvis.Infrastructure.DataAccess.EfCoreDa;

namespace YourJarvis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        #region MyRegion
        //private readonly YourJarvisContext _context;
        private readonly IServiceRepository<Article> _articleService;
        private readonly IServiceRepository<Alan> _alanService; 

        public ArticlesController(YourJarvisContext context, IServiceRepository<Article> articleService
            , IServiceRepository<Alan> alanService 
            )
        {
            //_context = context;
            _articleService = articleService;
            _alanService = alanService;
        }
        #region YeniMetodlar

        public async Task<IActionResult> AddTagToArticle() 
        {
            var yourJarvisContext = _context.Articles.Include(a => a.Alan);
            return View(await yourJarvisContext.ToListAsync());
        }
        #endregion
        // GET: Admin/Articles
        public IActionResult Index()
        {
            return View(_articleService.Index());
        }

        // GET: Admin/Articles/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _articleService.Details((int)id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        

        // GET: Admin/Articles/Create
        public IActionResult Create()
        {
            ViewData["AlanId"] = new SelectList(_alanService.Index(), "Id", "Title");
            return View();
        }

        // POST: Admin/Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ArticleId,ArticleTitle,ArticleSummary,ArticleDateCreated,ArticleDateModified,ArticleBody,ArticleViewCount,ArticleStatus,IsOpenForComment,AlanId")] Article article)
        {
            if (ModelState.IsValid)
            {
                _articleService.Create(article);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlanId"] = new SelectList(_alanService.Index(), "Id", "Title", article.AlanId);
            return View(article);
        }
        #endregion

        // GET: Admin/Articles/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _articleService.Details((int)id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["AlanId"] = new SelectList(_alanService.Index(), "Id", "Title", article.AlanId);
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ArticleId,ArticleTitle,ArticleSummary,ArticleDateCreated,ArticleDateModified,ArticleBody,ArticleViewCount,ArticleStatus,IsOpenForComment,AlanId")] Article article)
        {
            if (id != article.ArticleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _articleService.Edit(article);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ArticleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlanId"] = new SelectList(_alanService.Index(), "Id", "Title", article.AlanId);
            return View(article);
        }

        // GET: Admin/Articles/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _articleService.Details((int)id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var article = _articleService.Details((int)id);
            _articleService.Delete(article);
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _articleService.Index().Any(e => e.ArticleId == id);
        }

        
    }
}
