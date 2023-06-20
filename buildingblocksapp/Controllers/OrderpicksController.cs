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
    public class OrderpicksController : Controller
    {
        private readonly BuildingblocksContext _context;

        public OrderpicksController(BuildingblocksContext context)
        {
            _context = context;
        }

        // GET: Orderpicks
        public async Task<IActionResult> Index()
        {
              return _context.Orderpicks != null ? 
                          View(await _context.Orderpicks.ToListAsync()) :
                          Problem("Entity set 'BuildingblocksContext.Orderpicks'  is null.");
        }

        // GET: Orderpicks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orderpicks == null)
            {
                return NotFound();
            }

            var orderpick = await _context.Orderpicks
                .FirstOrDefaultAsync(m => m.OrderpickId == id);
            if (orderpick == null)
            {
                return NotFound();
            }

            return View(orderpick);
        }

        // GET: Orderpicks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orderpicks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderpickId,WerkorderId,PeriodeAanvraag,PeriodeLevering,Rood,Grijs,Blauw,AkkoordProductie")] Orderpick orderpick)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderpick);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderpick);
        }

        // GET: Orderpicks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orderpicks == null)
            {
                return NotFound();
            }

            var orderpick = await _context.Orderpicks.FindAsync(id);
            if (orderpick == null)
            {
                return NotFound();
            }
            return View(orderpick);
        }

        // POST: Orderpicks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderpickId,WerkorderId,PeriodeAanvraag,PeriodeLevering,Rood,Grijs,Blauw,AkkoordProductie")] Orderpick orderpick)
        {
            if (id != orderpick.OrderpickId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderpick);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderpickExists(orderpick.OrderpickId))
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
            return View(orderpick);
        }

        // GET: Orderpicks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orderpicks == null)
            {
                return NotFound();
            }

            var orderpick = await _context.Orderpicks
                .FirstOrDefaultAsync(m => m.OrderpickId == id);
            if (orderpick == null)
            {
                return NotFound();
            }

            return View(orderpick);
        }

        // POST: Orderpicks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orderpicks == null)
            {
                return Problem("Entity set 'BuildingblocksContext.Orderpicks'  is null.");
            }
            var orderpick = await _context.Orderpicks.FindAsync(id);
            if (orderpick != null)
            {
                _context.Orderpicks.Remove(orderpick);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderpickExists(int id)
        {
          return (_context.Orderpicks?.Any(e => e.OrderpickId == id)).GetValueOrDefault();
        }
    }
}
