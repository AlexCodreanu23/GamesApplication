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
    public class SystemRequirementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SystemRequirementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SystemRequirements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SystemRequirements.Include(s => s.Game);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SystemRequirements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SystemRequirements == null)
            {
                return NotFound();
            }

            var systemRequirements = await _context.SystemRequirements
                .Include(s => s.Game)
                .FirstOrDefaultAsync(m => m.RequirementsId == id);
            if (systemRequirements == null)
            {
                return NotFound();
            }

            return View(systemRequirements);
        }

        // GET: SystemRequirements/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId");
            return View();
        }

        // POST: SystemRequirements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequirementsId,GameId,MinimumCPU,RecommendedCPU,MinimumRAM,RecommendedRAM,RecommendedGraphics,StorageRequired")] SystemRequirements systemRequirements)
        {
            if (ModelState.IsValid)
            {
                _context.Add(systemRequirements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", systemRequirements.GameId);
            return View(systemRequirements);
        }

        // GET: SystemRequirements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SystemRequirements == null)
            {
                return NotFound();
            }

            var systemRequirements = await _context.SystemRequirements.FindAsync(id);
            if (systemRequirements == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", systemRequirements.GameId);
            return View(systemRequirements);
        }

        // POST: SystemRequirements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequirementsId,GameId,MinimumCPU,RecommendedCPU,MinimumRAM,RecommendedRAM,RecommendedGraphics,StorageRequired")] SystemRequirements systemRequirements)
        {
            if (id != systemRequirements.RequirementsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemRequirements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemRequirementsExists(systemRequirements.RequirementsId))
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
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", systemRequirements.GameId);
            return View(systemRequirements);
        }

        // GET: SystemRequirements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SystemRequirements == null)
            {
                return NotFound();
            }

            var systemRequirements = await _context.SystemRequirements
                .Include(s => s.Game)
                .FirstOrDefaultAsync(m => m.RequirementsId == id);
            if (systemRequirements == null)
            {
                return NotFound();
            }

            return View(systemRequirements);
        }

        // POST: SystemRequirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SystemRequirements == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SystemRequirements'  is null.");
            }
            var systemRequirements = await _context.SystemRequirements.FindAsync(id);
            if (systemRequirements != null)
            {
                _context.SystemRequirements.Remove(systemRequirements);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SystemRequirementsExists(int id)
        {
          return (_context.SystemRequirements?.Any(e => e.RequirementsId == id)).GetValueOrDefault();
        }
    }
}
