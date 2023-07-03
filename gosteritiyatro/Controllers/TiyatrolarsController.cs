using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gosteritiyatro.Models;

namespace gosteritiyatro.Controllers
{
    public class TiyatrolarsController : Controller
    {
        private readonly gosteriContext _context;

        public TiyatrolarsController(gosteriContext context)
        {
            _context = context;
        }

        // GET: Tiyatrolars
        public async Task<IActionResult> Index()
        {
              return _context.Tiyatrolars != null ? 
                          View(await _context.Tiyatrolars.ToListAsync()) :
                          Problem("Entity set 'gosteriContext.Tiyatrolars'  is null.");
        }

        // GET: Tiyatrolars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tiyatrolars == null)
            {
                return NotFound();
            }

            var tiyatrolar = await _context.Tiyatrolars
                .FirstOrDefaultAsync(m => m.TiyatroId == id);
            if (tiyatrolar == null)
            {
                return NotFound();
            }

            return View(tiyatrolar);
        }

        // GET: Tiyatrolars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tiyatrolars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TiyatroId,Ad,Adres,Sehir,Ulke")] Tiyatrolar tiyatrolar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiyatrolar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiyatrolar);
        }

        // GET: Tiyatrolars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tiyatrolars == null)
            {
                return NotFound();
            }

            var tiyatrolar = await _context.Tiyatrolars.FindAsync(id);
            if (tiyatrolar == null)
            {
                return NotFound();
            }
            return View(tiyatrolar);
        }

        // POST: Tiyatrolars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TiyatroId,Ad,Adres,Sehir,Ulke")] Tiyatrolar tiyatrolar)
        {
            if (id != tiyatrolar.TiyatroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiyatrolar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiyatrolarExists(tiyatrolar.TiyatroId))
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
            return View(tiyatrolar);
        }

        // GET: Tiyatrolars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tiyatrolars == null)
            {
                return NotFound();
            }

            var tiyatrolar = await _context.Tiyatrolars
                .FirstOrDefaultAsync(m => m.TiyatroId == id);
            if (tiyatrolar == null)
            {
                return NotFound();
            }

            return View(tiyatrolar);
        }

        // POST: Tiyatrolars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tiyatrolars == null)
            {
                return Problem("Entity set 'gosteriContext.Tiyatrolars'  is null.");
            }
            var tiyatrolar = await _context.Tiyatrolars.FindAsync(id);
            if (tiyatrolar != null)
            {
                _context.Tiyatrolars.Remove(tiyatrolar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiyatrolarExists(int id)
        {
          return (_context.Tiyatrolars?.Any(e => e.TiyatroId == id)).GetValueOrDefault();
        }
    }
}
