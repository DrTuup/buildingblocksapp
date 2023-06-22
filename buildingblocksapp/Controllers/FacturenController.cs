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
    public class FacturenController : Controller
    {
        private readonly BuildingblocksContext _context;

        public FacturenController(BuildingblocksContext context)
        {
            _context = context;
        }

        // GET: Facturen
        public async Task<IActionResult> Index()
        {
            var buildingblocksContext = _context.Factuur.Include(f => f.Klantorder);
            return View(await buildingblocksContext.ToListAsync());
        }

        // GET: Facturen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Factuur == null)
            {
                return NotFound();
            }

            var factuur = await _context.Factuur
                .Include(f => f.Klantorder)
                .FirstOrDefaultAsync(m => m.FactuurId == id);
            if (factuur == null)
            {
                return NotFound();
            }

            return View(factuur);
        }

        // GET: Facturen/Create
        public IActionResult Create()
        {
            ViewData["KlantorderId"] = new SelectList(_context.Klantorders, "KlantorderId", "Naam");
            return View();
        }

        // POST: Facturen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FactuurId,Factuurdatum,KlantorderId,TotaalBedrag,VoldaanBedrag,Betaaldatum,Betaalstatus")] Factuur factuur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factuur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlantorderId"] = new SelectList(_context.Klantorders, "KlantorderId", "Naam", factuur.KlantorderId);
            return View(factuur);
        }

        // GET: Facturen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Factuur == null)
            {
                return NotFound();
            }

            var factuur = await _context.Factuur.FindAsync(id);
            if (factuur == null)
            {
                return NotFound();
            }
            ViewData["KlantorderId"] = new SelectList(_context.Klantorders, "KlantorderId", "Naam", factuur.KlantorderId);
            return View(factuur);
        }

        // POST: Facturen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FactuurId,Factuurdatum,KlantorderId,TotaalBedrag,VoldaanBedrag,Betaaldatum,Betaalstatus")] Factuur factuur)
        {
            if (id != factuur.FactuurId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factuur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactuurExists(factuur.FactuurId))
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
            ViewData["KlantorderId"] = new SelectList(_context.Klantorders, "KlantorderId", "Naam", factuur.KlantorderId);
            return View(factuur);
        }

        // GET: Facturen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Factuur == null)
            {
                return NotFound();
            }

            var factuur = await _context.Factuur
                .Include(f => f.Klantorder)
                .FirstOrDefaultAsync(m => m.FactuurId == id);
            if (factuur == null)
            {
                return NotFound();
            }

            return View(factuur);
        }

        // POST: Facturen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Factuur == null)
            {
                return Problem("Entity set 'BuildingblocksContext.Factuur'  is null.");
            }
            var factuur = await _context.Factuur.FindAsync(id);
            if (factuur != null)
            {
                _context.Factuur.Remove(factuur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactuurExists(int id)
        {
          return (_context.Factuur?.Any(e => e.FactuurId == id)).GetValueOrDefault();
        }
    }
}
