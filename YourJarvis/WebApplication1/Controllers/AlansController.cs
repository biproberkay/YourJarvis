using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YourJarvis.ApplicationCore.Entities;
using YourJarvis.Infrastructure.DataAccess.EfCore;

namespace WebApplication1.Controllers
{
    public class AlansController : Controller
    {
        private readonly YourJarvisContext _context;

        public AlansController(YourJarvisContext context)
        {
            _context = context;
        }

        // GET: Alans
        public async Task<IActionResult> Index()
        {
            var yourJarvisContext = _context.Alans.Include(a => a.Parent);
            return View(await yourJarvisContext.ToListAsync());
        }

        // GET: Alans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var alan = await _context.Alans
                .Include(a=>a.Articles)
                .Include(a => a.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alan == null)
            {
                return NotFound();
            }
            ViewData["Articles"] = await _context.Articles.Where(a => a.AlanId == id).ToListAsync();

            return View(alan);
        }

        // GET: Alans/Create
        public IActionResult Create()
        {
            ViewData["ParentId"] = new SelectList(_context.Alans, "Id", "Id");
            return View();
        }

        // POST: Alans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Level,ParentId")] Alan alan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentId"] = new SelectList(_context.Alans, "Id", "Id", alan.ParentId);
            return View(alan);
        }

        // GET: Alans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alan = await _context.Alans.FindAsync(id);
            if (alan == null)
            {
                return NotFound();
            }
            ViewData["ParentId"] = new SelectList(_context.Alans, "Id", "Id", alan.ParentId);
            return View(alan);
        }

        // POST: Alans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Level,ParentId")] Alan alan)
        {
            if (id != alan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlanExists(alan.Id))
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
            ViewData["ParentId"] = new SelectList(_context.Alans, "Id", "Id", alan.ParentId);
            return View(alan);
        }

        // GET: Alans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alan = await _context.Alans
                .Include(a => a.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alan == null)
            {
                return NotFound();
            }

            return View(alan);
        }

        // POST: Alans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alan = await _context.Alans.FindAsync(id);
            _context.Alans.Remove(alan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlanExists(int id)
        {
            return _context.Alans.Any(e => e.Id == id);
        }
    }
}
