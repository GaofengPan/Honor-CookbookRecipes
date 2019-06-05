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
    public class CmenusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CmenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cmenus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cmenus.ToListAsync());
        }

        // GET: Cmenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmenu = await _context.Cmenus
                .FirstOrDefaultAsync(m => m.CmenuId == id);
            if (cmenu == null)
            {
                return NotFound();
            }

            return View(cmenu);
        }

        // GET: Cmenus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cmenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CmenuId,DishName,Prices,PictureUrl,Name")] Cmenu cmenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cmenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cmenu);
        }

        // GET: Cmenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmenu = await _context.Cmenus.FindAsync(id);
            if (cmenu == null)
            {
                return NotFound();
            }
            return View(cmenu);
        }

        // POST: Cmenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CmenuId,DishName,Prices,PictureUrl,Name")] Cmenu cmenu)
        {
            if (id != cmenu.CmenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cmenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CmenuExists(cmenu.CmenuId))
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
            return View(cmenu);
        }

        // GET: Cmenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmenu = await _context.Cmenus
                .FirstOrDefaultAsync(m => m.CmenuId == id);
            if (cmenu == null)
            {
                return NotFound();
            }

            return View(cmenu);
        }

        // POST: Cmenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cmenu = await _context.Cmenus.FindAsync(id);
            _context.Cmenus.Remove(cmenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CmenuExists(int id)
        {
            return _context.Cmenus.Any(e => e.CmenuId == id);
        }
    }
}
