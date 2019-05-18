using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Honor_CookbookRecipes.Data;
using Honor_CookbookRecipes.Models;

namespace Honor_CookbookRecipes.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmenusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CmenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cmenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cmenu>>> GetCmenus()
        {
            return await _context.Cmenus.ToListAsync();
        }

        // GET: api/Cmenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cmenu>> GetCmenu(int id)
        {
            var cmenu = await _context.Cmenus.FindAsync(id);

            if (cmenu == null)
            {
                return NotFound();
            }

            return cmenu;
        }

        // PUT: api/Cmenus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCmenu(int id, Cmenu cmenu)
        {
            if (id != cmenu.CmenuId)
            {
                return BadRequest();
            }

            _context.Entry(cmenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CmenuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cmenus
        [HttpPost]
        public async Task<ActionResult<Cmenu>> PostCmenu(Cmenu cmenu)
        {
            _context.Cmenus.Add(cmenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCmenu", new { id = cmenu.CmenuId }, cmenu);
        }

        // DELETE: api/Cmenus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cmenu>> DeleteCmenu(int id)
        {
            var cmenu = await _context.Cmenus.FindAsync(id);
            if (cmenu == null)
            {
                return NotFound();
            }

            _context.Cmenus.Remove(cmenu);
            await _context.SaveChangesAsync();

            return cmenu;
        }

        private bool CmenuExists(int id)
        {
            return _context.Cmenus.Any(e => e.CmenuId == id);
        }
    }
}
