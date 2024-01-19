using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevelopersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Developers
        public async Task<IActionResult> Index()
        {
              return _context.Developers != null ? 
                          View(await _context.Developers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Developers'  is null.");
        }

        // GET: Developers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Developers == null)
            {
                return NotFound();
            }

            var developers = await _context.Developers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (developers == null)
            {
                return NotFound();
            }

            return View(developers);
        }

        // GET: Developers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Developers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Country,Email,Salary")] Developers developers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(developers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(developers);
        }

        // GET: Developers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Developers == null)
            {
                return NotFound();
            }

            var developers = await _context.Developers.FindAsync(id);
            if (developers == null)
            {
                return NotFound();
            }
            return View(developers);
        }

        // POST: Developers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Country,Email,Salary")] Developers developers)
        {
            if (id != developers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(developers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevelopersExists(developers.Id))
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
            return View(developers);
        }

        // GET: Developers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Developers == null)
            {
                return NotFound();
            }

            var developers = await _context.Developers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (developers == null)
            {
                return NotFound();
            }

            return View(developers);
        }

        // POST: Developers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Developers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Developers'  is null.");
            }
            var developers = await _context.Developers.FindAsync(id);
            if (developers != null)
            {
                _context.Developers.Remove(developers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevelopersExists(int id)
        {
          return (_context.Developers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
