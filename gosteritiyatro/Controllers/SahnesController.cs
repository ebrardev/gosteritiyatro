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
    public class SahnesController : Controller
    {
        private readonly gosteriContext _context;

        public SahnesController(gosteriContext context)
        {
            _context = context;
        }

        // GET: Sahnes
        public async Task<IActionResult> Index()
        {
            var gosteriContext = _context.Sahnes.Include(s => s.Tiyatro);
            return View(await gosteriContext.ToListAsync());
        }

        // GET: Sahnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sahnes == null)
            {
                return NotFound();
            }

            var sahne = await _context.Sahnes
                .Include(s => s.Tiyatro)
                .FirstOrDefaultAsync(m => m.SahneId == id);
            if (sahne == null)
            {
                return NotFound();
            }

            return View(sahne);
        }

        // GET: Sahnes/Create
        public IActionResult Create()
        {
            ViewData["TiyatroId"] = new SelectList(_context.Tiyatrolars, "TiyatroId", "TiyatroId");
            return View();
        }

        // POST: Sahnes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SahneId,TiyatroId,Ad,Kapasite")] Sahne sahne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sahne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TiyatroId"] = new SelectList(_context.Tiyatrolars, "TiyatroId", "TiyatroId", sahne.TiyatroId);
            return View(sahne);
        }

        // GET: Sahnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sahnes == null)
            {
                return NotFound();
            }

            var sahne = await _context.Sahnes.FindAsync(id);
            if (sahne == null)
            {
                return NotFound();
            }
            ViewData["TiyatroId"] = new SelectList(_context.Tiyatrolars, "TiyatroId", "TiyatroId", sahne.TiyatroId);
            return View(sahne);
        }

        // POST: Sahnes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SahneId,TiyatroId,Ad,Kapasite")] Sahne sahne)
        {
            if (id != sahne.SahneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sahne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SahneExists(sahne.SahneId))
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
            ViewData["TiyatroId"] = new SelectList(_context.Tiyatrolars, "TiyatroId", "TiyatroId", sahne.TiyatroId);
            return View(sahne);
        }

        // GET: Sahnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sahnes == null)
            {
                return NotFound();
            }

            var sahne = await _context.Sahnes
                .Include(s => s.Tiyatro)
                .FirstOrDefaultAsync(m => m.SahneId == id);
            if (sahne == null)
            {
                return NotFound();
            }

            return View(sahne);
        }

        // POST: Sahnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sahnes == null)
            {
                return Problem("Entity set 'gosteriContext.Sahnes'  is null.");
            }
            var sahne = await _context.Sahnes.FindAsync(id);
            if (sahne != null)
            {
                _context.Sahnes.Remove(sahne);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SahneExists(int id)
        {
          return (_context.Sahnes?.Any(e => e.SahneId == id)).GetValueOrDefault();
        }
    }
}
