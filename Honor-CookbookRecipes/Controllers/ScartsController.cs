using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Honor_CookbookRecipes.Data;
using Honor_CookbookRecipes.Models;

namespace Honor_CookbookRecipes.Controllers
{
    public class ScartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Scarts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Scarts.Include(s => s.Cmenu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Scarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scart = await _context.Scarts
                .Include(s => s.Cmenu)
                .FirstOrDefaultAsync(m => m.ScartId == id);
            if (scart == null)
            {
                return NotFound();
            }

            return View(scart);
        }

        // GET: Scarts/Create
        public IActionResult Create()
        {
            ViewData["CmenuId"] = new SelectList(_context.Cmenus, "CmenuId", "CmenuId");
            return View();
        }

        // POST: Scarts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScartId,DishName,Prices,CmenuId")] Scart scart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CmenuId"] = new SelectList(_context.Cmenus, "CmenuId", "CmenuId", scart.CmenuId);
            return View(scart);
        }

        // GET: Scarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scart = await _context.Scarts.FindAsync(id);
            if (scart == null)
            {
                return NotFound();
            }
            ViewData["CmenuId"] = new SelectList(_context.Cmenus, "CmenuId", "CmenuId", scart.CmenuId);
            return View(scart);
        }

        // POST: Scarts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScartId,DishName,Prices,CmenuId")] Scart scart)
        {
            if (id != scart.ScartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScartExists(scart.ScartId))
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
            ViewData["CmenuId"] = new SelectList(_context.Cmenus, "CmenuId", "CmenuId", scart.CmenuId);
            return View(scart);
        }

        // GET: Scarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scart = await _context.Scarts
                .Include(s => s.Cmenu)
                .FirstOrDefaultAsync(m => m.ScartId == id);
            if (scart == null)
            {
                return NotFound();
            }

            return View(scart);
        }

        // POST: Scarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scart = await _context.Scarts.FindAsync(id);
            _context.Scarts.Remove(scart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScartExists(int id)
        {
            return _context.Scarts.Any(e => e.ScartId == id);
        }
    }
}
