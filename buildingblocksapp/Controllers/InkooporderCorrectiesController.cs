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
    public class InkooporderCorrectiesController : Controller
    {
        private readonly BuildingblocksContext _context;

        public InkooporderCorrectiesController(BuildingblocksContext context)
        {
            _context = context;
        }

        // GET: InkooporderCorrecties
        public async Task<IActionResult> Index()
        {
              return _context.InkooporderCorrecties != null ? 
                          View(await _context.InkooporderCorrecties.ToListAsync()) :
                          Problem("Entity set 'BuildingblocksContext.InkooporderCorrecties'  is null.");
        }

        // GET: InkooporderCorrecties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InkooporderCorrecties == null)
            {
                return NotFound();
            }

            var inkooporderCorrectie = await _context.InkooporderCorrecties
                .FirstOrDefaultAsync(m => m.InkooporderCorrectieId == id);
            if (inkooporderCorrectie == null)
            {
                return NotFound();
            }

            return View(inkooporderCorrectie);
        }

        // GET: InkooporderCorrecties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InkooporderCorrecties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InkooporderCorrectieId,InkooporderId,Rood,Grijs,Blauw")] InkooporderCorrectie inkooporderCorrectie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inkooporderCorrectie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inkooporderCorrectie);
        }

        // GET: InkooporderCorrecties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InkooporderCorrecties == null)
            {
                return NotFound();
            }

            var inkooporderCorrectie = await _context.InkooporderCorrecties.FindAsync(id);
            if (inkooporderCorrectie == null)
            {
                return NotFound();
            }
            return View(inkooporderCorrectie);
        }

        // POST: InkooporderCorrecties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InkooporderCorrectieId,InkooporderId,Rood,Grijs,Blauw")] InkooporderCorrectie inkooporderCorrectie)
        {
            if (id != inkooporderCorrectie.InkooporderCorrectieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inkooporderCorrectie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InkooporderCorrectieExists(inkooporderCorrectie.InkooporderCorrectieId))
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
            return View(inkooporderCorrectie);
        }

        // GET: InkooporderCorrecties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InkooporderCorrecties == null)
            {
                return NotFound();
            }

            var inkooporderCorrectie = await _context.InkooporderCorrecties
                .FirstOrDefaultAsync(m => m.InkooporderCorrectieId == id);
            if (inkooporderCorrectie == null)
            {
                return NotFound();
            }

            return View(inkooporderCorrectie);
        }

        // POST: InkooporderCorrecties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InkooporderCorrecties == null)
            {
                return Problem("Entity set 'BuildingblocksContext.InkooporderCorrecties'  is null.");
            }
            var inkooporderCorrectie = await _context.InkooporderCorrecties.FindAsync(id);
            if (inkooporderCorrectie != null)
            {
                _context.InkooporderCorrecties.Remove(inkooporderCorrectie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InkooporderCorrectieExists(int id)
        {
          return (_context.InkooporderCorrecties?.Any(e => e.InkooporderCorrectieId == id)).GetValueOrDefault();
        }
    }
}
