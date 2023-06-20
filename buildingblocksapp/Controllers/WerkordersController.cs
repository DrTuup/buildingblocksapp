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
    public class WerkordersController : Controller
    {
        private readonly BuildingblocksContext _context;

        public WerkordersController(BuildingblocksContext context)
        {
            _context = context;
        }

        // GET: Werkorders
        public async Task<IActionResult> Index()
        {
            var buildingblocksContext = _context.Werkorders.Include(w => w.Klantorder).Include(w => w.Orderpick);
            return View(await buildingblocksContext.ToListAsync());
        }

        // GET: Werkorders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Werkorders == null)
            {
                return NotFound();
            }

            var werkorder = await _context.Werkorders
                .Include(w => w.Klantorder)
                .Include(w => w.Orderpick)
                .FirstOrDefaultAsync(m => m.WerkorderId == id);
            if (werkorder == null)
            {
                return NotFound();
            }

            return View(werkorder);
        }

        // GET: Werkorders/Create
        public IActionResult Create()
        {
            ViewData["KlantOrder"] = new SelectList(_context.Klantorders, "KlantorderId", "Naam");
            ViewData["OrderpickId"] = new SelectList(_context.Orderpicks, "OrderpickId", "OrderpickId");
            return View();
        }

        // POST: Werkorders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WerkorderId,OrderpickId,KlantOrder,Motortype,LeverPeriode,AkkoordPanning")] Werkorder werkorder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(werkorder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlantOrder"] = new SelectList(_context.Klantorders, "KlantorderId", "Naam", werkorder.KlantOrder);
            ViewData["OrderpickId"] = new SelectList(_context.Orderpicks, "OrderpickId", "OrderpickId", werkorder.OrderpickId);
            return View(werkorder);
        }

        // GET: Werkorders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Werkorders == null)
            {
                return NotFound();
            }

            var werkorder = await _context.Werkorders.FindAsync(id);
            if (werkorder == null)
            {
                return NotFound();
            }
            ViewData["KlantOrder"] = new SelectList(_context.Klantorders, "KlantorderId", "Naam", werkorder.KlantOrder);
            ViewData["OrderpickId"] = new SelectList(_context.Orderpicks, "OrderpickId", "OrderpickId", werkorder.OrderpickId);
            return View(werkorder);
        }

        // POST: Werkorders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WerkorderId,OrderpickId,KlantOrder,Motortype,LeverPeriode,AkkoordPanning")] Werkorder werkorder)
        {
            if (id != werkorder.WerkorderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(werkorder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WerkorderExists(werkorder.WerkorderId))
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
            ViewData["KlantOrder"] = new SelectList(_context.Klantorders, "KlantorderId", "Naam", werkorder.KlantOrder);
            ViewData["OrderpickId"] = new SelectList(_context.Orderpicks, "OrderpickId", "OrderpickId", werkorder.OrderpickId);
            return View(werkorder);
        }

        // GET: Werkorders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Werkorders == null)
            {
                return NotFound();
            }

            var werkorder = await _context.Werkorders
                .Include(w => w.Klantorder)
                .Include(w => w.Orderpick)
                .FirstOrDefaultAsync(m => m.WerkorderId == id);
            if (werkorder == null)
            {
                return NotFound();
            }

            return View(werkorder);
        }

        // POST: Werkorders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Werkorders == null)
            {
                return Problem("Entity set 'BuildingblocksContext.Werkorders'  is null.");
            }
            var werkorder = await _context.Werkorders.FindAsync(id);
            if (werkorder != null)
            {
                _context.Werkorders.Remove(werkorder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WerkorderExists(int id)
        {
          return (_context.Werkorders?.Any(e => e.WerkorderId == id)).GetValueOrDefault();
        }
    }
}
