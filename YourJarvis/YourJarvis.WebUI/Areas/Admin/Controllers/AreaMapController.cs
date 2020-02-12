using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YourJarvis.ApplicationCore.Entities;
using YourJarvis.Infrastructure.DataAccess.EfCoreDa;

namespace YourJarvis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AreaMapController : Controller
    {
        private readonly YourJarvisContext _context;

        public AreaMapController(YourJarvisContext context)
        {
            _context = context;
        }

        // GET: Admin/AreaMap
        public async Task<IActionResult> Index()
        {
            var yourJarvisContext = _context.Alans.Include(a => a.Parent);
            return View(await yourJarvisContext.ToListAsync());
        }

        // GET: Admin/AreaMap/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Admin/AreaMap/Create
        public IActionResult Create()
        {
            ViewData["ParentId"] = new SelectList(_context.Alans, "Id", "Id");
            return View();
        }

        // POST: Admin/AreaMap/Create
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

        // GET: Admin/AreaMap/Edit/5
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

        // POST: Admin/AreaMap/Edit/5
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

        // GET: Admin/AreaMap/Delete/5
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

        // POST: Admin/AreaMap/Delete/5
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
