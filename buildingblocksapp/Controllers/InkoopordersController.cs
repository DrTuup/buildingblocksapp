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
    public class InkoopordersController : Controller
    {
        private readonly BuildingblocksContext _context;

        public InkoopordersController(BuildingblocksContext context)
        {
            _context = context;
        }

        // GET: Inkooporders
        public async Task<IActionResult> Index()
        {
            var buildingblocksContext = _context.Inkooporders.Include(i => i.InkooporderCorrectie);
            return View(await buildingblocksContext.ToListAsync());
        }

        // GET: Inkooporders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inkooporders == null)
            {
                return NotFound();
            }

            var inkooporder = await _context.Inkooporders
                .Include(i => i.InkooporderCorrectie)
                .FirstOrDefaultAsync(m => m.InkooporderId == id);
            if (inkooporder == null)
            {
                return NotFound();
            }

            return View(inkooporder);
        }

        // GET: Inkooporders/Create
        public IActionResult Create()
        {
            ViewData["InkooporderCorrectieId"] = new SelectList(_context.InkooporderCorrecties, "InkooporderCorrectieId", "InkooporderCorrectieId");
            return View();
        }

        // POST: Inkooporders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InkooporderId,InkooporderCorrectieId,PeriodeBinnenkomst,PeriodeVerwerkt,Rood,Grijs,Blauw")] Inkooporder inkooporder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inkooporder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InkooporderCorrectieId"] = new SelectList(_context.InkooporderCorrecties, "InkooporderCorrectieId", "InkooporderCorrectieId", inkooporder.InkooporderCorrectieId);
            return View(inkooporder);
        }

        // GET: Inkooporders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inkooporders == null)
            {
                return NotFound();
            }

            var inkooporder = await _context.Inkooporders.FindAsync(id);
            if (inkooporder == null)
            {
                return NotFound();
            }
            ViewData["InkooporderCorrectieId"] = new SelectList(_context.InkooporderCorrecties, "InkooporderCorrectieId", "InkooporderCorrectieId", inkooporder.InkooporderCorrectieId);
            return View(inkooporder);
        }

        // POST: Inkooporders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InkooporderId,InkooporderCorrectieId,PeriodeBinnenkomst,PeriodeVerwerkt,Rood,Grijs,Blauw")] Inkooporder inkooporder)
        {
            if (id != inkooporder.InkooporderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inkooporder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InkooporderExists(inkooporder.InkooporderId))
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
            ViewData["InkooporderCorrectieId"] = new SelectList(_context.InkooporderCorrecties, "InkooporderCorrectieId", "InkooporderCorrectieId", inkooporder.InkooporderCorrectieId);
            return View(inkooporder);
        }

        // GET: Inkooporders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inkooporders == null)
            {
                return NotFound();
            }

            var inkooporder = await _context.Inkooporders
                .Include(i => i.InkooporderCorrectie)
                .FirstOrDefaultAsync(m => m.InkooporderId == id);
            if (inkooporder == null)
            {
                return NotFound();
            }

            return View(inkooporder);
        }

        // POST: Inkooporders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inkooporders == null)
            {
                return Problem("Entity set 'BuildingblocksContext.Inkooporders'  is null.");
            }
            var inkooporder = await _context.Inkooporders.FindAsync(id);
            if (inkooporder != null)
            {
                _context.Inkooporders.Remove(inkooporder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InkooporderExists(int id)
        {
          return (_context.Inkooporders?.Any(e => e.InkooporderId == id)).GetValueOrDefault();
        }
    }
}
