using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;
using YourJarvis.Infrastructure.DataAccess.EfCore;

namespace YourJarvis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleTagsController : Controller
    {
        private readonly YourJarvisContext _context;

        public ArticleTagsController(YourJarvisContext context)
        {
            _context = context;
        }

        // GET: Admin/ArticleTags
        public async Task<IActionResult> Index()
        {
            var yourJarvisContext = _context.ArticleTags.Include(a => a.Article).Include(a => a.Tag);
            return View(await yourJarvisContext.ToListAsync());
        }

        // GET: Admin/ArticleTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleTag = await _context.ArticleTags
                .Include(a => a.Article)
                .Include(a => a.Tag)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (articleTag == null)
            {
                return NotFound();
            }

            return View(articleTag);
        }

        // GET: Admin/ArticleTags/Create
        public IActionResult Create()
        {
            ViewData["ArticleId"] = new SelectList(_context.Articles, "ArticleId", "ArticleBody");
            ViewData["TagId"] = new SelectList(_context.Tags, "TagId", "TagName");
            return View();
        }

        // POST: Admin/ArticleTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleId,TagId")] ArticleTag articleTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articleTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticleId"] = new SelectList(_context.Articles, "ArticleId", "ArticleBody", articleTag.ArticleId);
            ViewData["TagId"] = new SelectList(_context.Tags, "TagId", "TagName", articleTag.TagId);
            return View(articleTag);
        }

        // GET: Admin/ArticleTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleTag = await _context.ArticleTags.FindAsync(id);
            if (articleTag == null)
            {
                return NotFound();
            }
            ViewData["ArticleId"] = new SelectList(_context.Articles, "ArticleId", "ArticleBody", articleTag.ArticleId);
            ViewData["TagId"] = new SelectList(_context.Tags, "TagId", "TagName", articleTag.TagId);
            return View(articleTag);
        }

        // POST: Admin/ArticleTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleId,TagId")] ArticleTag articleTag)
        {
            if (id != articleTag.ArticleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articleTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleTagExists(articleTag.ArticleId))
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
            ViewData["ArticleId"] = new SelectList(_context.Articles, "ArticleId", "ArticleBody", articleTag.ArticleId);
            ViewData["TagId"] = new SelectList(_context.Tags, "TagId", "TagName", articleTag.TagId);
            return View(articleTag);
        }

        // GET: Admin/ArticleTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleTag = await _context.ArticleTags
                .Include(a => a.Article)
                .Include(a => a.Tag)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (articleTag == null)
            {
                return NotFound();
            }

            return View(articleTag);
        }

        // POST: Admin/ArticleTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articleTag = await _context.ArticleTags.FindAsync(id);
            _context.ArticleTags.Remove(articleTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleTagExists(int id)
        {
            return _context.ArticleTags.Any(e => e.ArticleId == id);
        }
    }
}
