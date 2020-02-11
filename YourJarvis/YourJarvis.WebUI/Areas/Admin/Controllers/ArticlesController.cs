﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;
using YourJarvis.ApplicationCore.ServiceInterfaces;
using YourJarvis.Infrastructure.DataAccess.EfCore;

namespace YourJarvis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        #region MyRegion
        private readonly YourJarvisContext _context;
        private readonly IArticleService _articleService; 

        public ArticlesController(YourJarvisContext context, IArticleService articleService)
        {
            _context = context;
            _articleService = articleService;
        }
        #region YeniMetodlar

        public async Task<IActionResult> AddTagToArticle() 
        {
            var yourJarvisContext = _context.Articles.Include(a => a.Alan);
            return View(await yourJarvisContext.ToListAsync());
        }
        #endregion
        // GET: Admin/Articles
        public async Task<IActionResult> Index()
        {
            var yourJarvisContext = _context.Articles.Include(a => a.Alan);
            return View(await yourJarvisContext.ToListAsync());
        }

        // GET: Admin/Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Alan)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        

        // GET: Admin/Articles/Create
        public IActionResult Create()
        {
            ViewData["AlanId"] = new SelectList(_context.Alans, "Id", "Id");
            return View();
        }

        // POST: Admin/Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleId,ArticleTitle,ArticleSummary,ArticleDateCreated,ArticleDateModified,ArticleBody,ArticleViewCount,ArticleStatus,IsOpenForComment,AlanId")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlanId"] = new SelectList(_context.Alans, "Id", "Id", article.AlanId);
            return View(article);
        }
        #endregion

        // GET: Admin/Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["AlanId"] = new SelectList(_context.Alans, "Id", "Id", article.AlanId);
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleId,ArticleTitle,ArticleSummary,ArticleDateCreated,ArticleDateModified,ArticleBody,ArticleViewCount,ArticleStatus,IsOpenForComment,AlanId")] Article article)
        {
            if (id != article.ArticleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
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
            ViewData["AlanId"] = new SelectList(_context.Alans, "Id", "Id", article.AlanId);
            return View(article);
        }

        // GET: Admin/Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Alan)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
        #region IDCUD
        // GET: Admin/Articles/Create
        public IActionResult CreateY()
        {
            ViewData["AlanId"] = new SelectList(_articleService.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Admin/Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateY(Article article)
        {
            if (ModelState.IsValid)
            {
                _articleService.Create(article);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlanId"] = new SelectList(_context.Alans, "Id", "Id", article.AlanId);
            return View(article);
        }

        // GET: Admin/Articles/Edit/5
        public async Task<IActionResult> EditY(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _articleService. FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["AlanId"] = new SelectList(_context.Alans, "Id", "Id", article.AlanId);
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditY(int id, [Bind("ArticleId,ArticleTitle,ArticleSummary,ArticleDateCreated,ArticleDateModified,ArticleBody,ArticleViewCount,ArticleStatus,IsOpenForComment,AlanId")] Article article)
        {
            if (id != article.ArticleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
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
            ViewData["AlanId"] = new SelectList(_context.Alans, "Id", "Id", article.AlanId);
            return View(article);
        }

        #endregion
    }
}
