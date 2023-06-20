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
    public class KlantordersController : Controller
    {
        private readonly BuildingblocksContext _context;

        public KlantordersController(BuildingblocksContext context)
        {
            _context = context;
        }

        // GET: Klantorders
        public async Task<IActionResult> Index()
        {
              return _context.Klantorders != null ? 
                          View(await _context.Klantorders.ToListAsync()) :
                          Problem("Entity set 'BuildingblocksContext.Klantorders'  is null.");
        }

        // GET: Klantorders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Klantorders == null)
            {
                return NotFound();
            }

            var klantorder = await _context.Klantorders
                .FirstOrDefaultAsync(m => m.KlantorderId == id);
            if (klantorder == null)
            {
                return NotFound();
            }

            return View(klantorder);
        }

        // GET: Klantorders/Create
        public IActionResult Create()
        {
            var klantorder = new Klantorder();
            klantorder.Referentienummer = klantorder.GenerateRandomString(4);
            return View(klantorder);
        }

        // POST: Klantorders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KlantorderId,Naam,Aantal,Type,Referentienummer,AkkoordAccountmanager")] Klantorder klantorder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klantorder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klantorder);
        }

        // GET: Klantorders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Klantorders == null)
            {
                return NotFound();
            }

            var klantorder = await _context.Klantorders.FindAsync(id);
            if (klantorder == null)
            {
                return NotFound();
            }
            return View(klantorder);
        }

        // POST: Klantorders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KlantorderId,Naam,Aantal,Type,Referentienummer,AkkoordAccountmanager")] Klantorder klantorder)
        {
            if (id != klantorder.KlantorderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klantorder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlantorderExists(klantorder.KlantorderId))
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
            return View(klantorder);
        }

        // GET: Klantorders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Klantorders == null)
            {
                return NotFound();
            }

            var klantorder = await _context.Klantorders
                .FirstOrDefaultAsync(m => m.KlantorderId == id);
            if (klantorder == null)
            {
                return NotFound();
            }

            return View(klantorder);
        }

        // POST: Klantorders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Klantorders == null)
            {
                return Problem("Entity set 'BuildingblocksContext.Klantorders'  is null.");
            }
            var klantorder = await _context.Klantorders.FindAsync(id);
            if (klantorder != null)
            {
                _context.Klantorders.Remove(klantorder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlantorderExists(int id)
        {
          return (_context.Klantorders?.Any(e => e.KlantorderId == id)).GetValueOrDefault();
        }
    }
}
