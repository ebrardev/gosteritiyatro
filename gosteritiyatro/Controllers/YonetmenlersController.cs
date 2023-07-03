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
    public class YonetmenlersController : Controller
    {
        private readonly gosteriContext _context;

        public YonetmenlersController(gosteriContext context)
        {
            _context = context;
        }

        // GET: Yonetmenlers
        public async Task<IActionResult> Index()
        {
              return _context.Yonetmenlers != null ? 
                          View(await _context.Yonetmenlers.ToListAsync()) :
                          Problem("Entity set 'gosteriContext.Yonetmenlers'  is null.");
        }

        // GET: Yonetmenlers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Yonetmenlers == null)
            {
                return NotFound();
            }

            var yonetmenler = await _context.Yonetmenlers
                .FirstOrDefaultAsync(m => m.YonetmenId == id);
            if (yonetmenler == null)
            {
                return NotFound();
            }

            return View(yonetmenler);
        }

        // GET: Yonetmenlers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yonetmenlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YonetmenId,Ad,Soyad,DogumTarihi,Ulke")] Yonetmenler yonetmenler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yonetmenler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yonetmenler);
        }

        // GET: Yonetmenlers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Yonetmenlers == null)
            {
                return NotFound();
            }

            var yonetmenler = await _context.Yonetmenlers.FindAsync(id);
            if (yonetmenler == null)
            {
                return NotFound();
            }
            return View(yonetmenler);
        }

        // POST: Yonetmenlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YonetmenId,Ad,Soyad,DogumTarihi,Ulke")] Yonetmenler yonetmenler)
        {
            if (id != yonetmenler.YonetmenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yonetmenler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YonetmenlerExists(yonetmenler.YonetmenId))
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
            return View(yonetmenler);
        }

        // GET: Yonetmenlers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Yonetmenlers == null)
            {
                return NotFound();
            }

            var yonetmenler = await _context.Yonetmenlers
                .FirstOrDefaultAsync(m => m.YonetmenId == id);
            if (yonetmenler == null)
            {
                return NotFound();
            }

            return View(yonetmenler);
        }

        // POST: Yonetmenlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Yonetmenlers == null)
            {
                return Problem("Entity set 'gosteriContext.Yonetmenlers'  is null.");
            }
            var yonetmenler = await _context.Yonetmenlers.FindAsync(id);
            if (yonetmenler != null)
            {
                _context.Yonetmenlers.Remove(yonetmenler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YonetmenlerExists(int id)
        {
          return (_context.Yonetmenlers?.Any(e => e.YonetmenId == id)).GetValueOrDefault();
        }
    }
}
