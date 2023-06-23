using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using buildingblocksapp;
using buildingblocksapp.Models;

namespace buildingblocksapp.Controllers
{
    public class BetalingenController : Controller
    {
        private readonly BuildingblocksContext _context;

        public BetalingenController(BuildingblocksContext context)
        {
            _context = context;
        }

        // GET: Betalingen
        public async Task<IActionResult> Index()
        {
            var buildingblocksContext = _context.Betalingen.Include(b => b.Factuur);
            return View(await buildingblocksContext.ToListAsync());
        }

        // GET: Betalingen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Betalingen == null)
            {
                return NotFound();
            }

            var betaling = await _context.Betalingen
                .Include(b => b.Factuur)
                .FirstOrDefaultAsync(m => m.BetalingId == id);
            if (betaling == null)
            {
                return NotFound();
            }

            return View(betaling);
        }

        // GET: Betalingen/Create
        public IActionResult Create()
        {
            ViewData["FactuurId"] = new SelectList(_context.Facturen, "FactuurId", "FactuurId");
            return View();
        }

        // POST: Betalingen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BetalingId,Betalingsdatum,Bedrag,FactuurId")] Betaling betaling)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("BetalingenController:Create");
                _context.Add(betaling);
                var factuur = await _context.Facturen.FindAsync(betaling.FactuurId);
                factuur?.UpdateBetaalstatus();

                await _context.SaveChangesAsync();                // get Factuur
                return RedirectToAction(nameof(Index));
            }
            ViewData["FactuurId"] = new SelectList(_context.Facturen, "FactuurId", "FactuurId", betaling.FactuurId);
            return View(betaling);
        }

        // GET: Betalingen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Betalingen == null)
            {
                return NotFound();
            }

            var betaling = await _context.Betalingen.FindAsync(id);
            if (betaling == null)
            {
                return NotFound();
            }
            ViewData["FactuurId"] = new SelectList(_context.Facturen, "FactuurId", "FactuurId", betaling.FactuurId);
            return View(betaling);
        }

        // POST: Betalingen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BetalingId,Betalingsdatum,Bedrag,FactuurId")] Betaling betaling)
        {
            if (id != betaling.BetalingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(betaling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BetalingExists(betaling.BetalingId))
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
            ViewData["FactuurId"] = new SelectList(_context.Facturen, "FactuurId", "FactuurId", betaling.FactuurId);
            return View(betaling);
        }

        // GET: Betalingen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Betalingen == null)
            {
                return NotFound();
            }

            var betaling = await _context.Betalingen
                .Include(b => b.Factuur)
                .FirstOrDefaultAsync(m => m.BetalingId == id);
            if (betaling == null)
            {
                return NotFound();
            }

            return View(betaling);
        }

        // POST: Betalingen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Betalingen == null)
            {
                return Problem("Entity set 'BuildingblocksContext.Betalingen'  is null.");
            }
            var betaling = await _context.Betalingen.FindAsync(id);
            if (betaling != null)
            {
                _context.Betalingen.Remove(betaling);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BetalingExists(int id)
        {
          return (_context.Betalingen?.Any(e => e.BetalingId == id)).GetValueOrDefault();
        }
    }
}
