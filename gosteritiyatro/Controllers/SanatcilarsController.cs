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
    public class SanatcilarsController : Controller
    {
        private readonly gosteriContext _context;

        public SanatcilarsController(gosteriContext context)
        {
            _context = context;
        }

        // GET: Sanatcilars
        public async Task<IActionResult> Index()
        {
              return _context.Sanatcilars != null ? 
                          View(await _context.Sanatcilars.ToListAsync()) :
                          Problem("Entity set 'gosteriContext.Sanatcilars'  is null.");
        }

        // GET: Sanatcilars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sanatcilars == null)
            {
                return NotFound();
            }

            var sanatcilar = await _context.Sanatcilars
                .FirstOrDefaultAsync(m => m.SanatciId == id);
            if (sanatcilar == null)
            {
                return NotFound();
            }

            return View(sanatcilar);
        }

        // GET: Sanatcilars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sanatcilars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SanatciId,Ad,Soyad,DogumTarihi,Ulke")] Sanatcilar sanatcilar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanatcilar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanatcilar);
        }

        // GET: Sanatcilars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sanatcilars == null)
            {
                return NotFound();
            }

            var sanatcilar = await _context.Sanatcilars.FindAsync(id);
            if (sanatcilar == null)
            {
                return NotFound();
            }
            return View(sanatcilar);
        }

        // POST: Sanatcilars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SanatciId,Ad,Soyad,DogumTarihi,Ulke")] Sanatcilar sanatcilar)
        {
            if (id != sanatcilar.SanatciId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanatcilar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanatcilarExists(sanatcilar.SanatciId))
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
            return View(sanatcilar);
        }

        // GET: Sanatcilars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sanatcilars == null)
            {
                return NotFound();
            }

            var sanatcilar = await _context.Sanatcilars
                .FirstOrDefaultAsync(m => m.SanatciId == id);
            if (sanatcilar == null)
            {
                return NotFound();
            }

            return View(sanatcilar);
        }

        // POST: Sanatcilars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sanatcilars == null)
            {
                return Problem("Entity set 'gosteriContext.Sanatcilars'  is null.");
            }
            var sanatcilar = await _context.Sanatcilars.FindAsync(id);
            if (sanatcilar != null)
            {
                _context.Sanatcilars.Remove(sanatcilar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanatcilarExists(int id)
        {
          return (_context.Sanatcilars?.Any(e => e.SanatciId == id)).GetValueOrDefault();
        }
    }
}
