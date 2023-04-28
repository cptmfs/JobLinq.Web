using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobLinq.Web.Models;

namespace JobLinq.Web.Controllers
{
    public class TblilansController : Controller
    {
        private readonly DbjoblinqContext _context;

        public TblilansController(DbjoblinqContext context)
        {
            _context = context;
        }

        // GET: Tblilans
        public async Task<IActionResult> Index()
        {
              return _context.Tblilans != null ? 
                          View(await _context.Tblilans.ToListAsync()) :
                          Problem("Entity set 'DbjoblinqContext.Tblilans'  is null.");
        }

        // GET: Tblilans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tblilans == null)
            {
                return NotFound();
            }

            var tblilan = await _context.Tblilans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblilan == null)
            {
                return NotFound();
            }

            return View(tblilan);
        }

        // GET: Tblilans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tblilans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sirket,Departman,Tecrube,EgitimSeviyesi,YabancilDil,CalismaSekli,Pozisyon,Sehir,IlanDetay")] Tblilan tblilan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblilan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblilan);
        }

        // GET: Tblilans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tblilans == null)
            {
                return NotFound();
            }

            var tblilan = await _context.Tblilans.FindAsync(id);
            if (tblilan == null)
            {
                return NotFound();
            }
            return View(tblilan);
        }

        // POST: Tblilans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sirket,Departman,Tecrube,EgitimSeviyesi,YabancilDil,CalismaSekli,Pozisyon,Sehir,IlanDetay")] Tblilan tblilan)
        {
            if (id != tblilan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblilan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblilanExists(tblilan.Id))
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
            return View(tblilan);
        }

        // GET: Tblilans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tblilans == null)
            {
                return NotFound();
            }

            var tblilan = await _context.Tblilans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblilan == null)
            {
                return NotFound();
            }

            return View(tblilan);
        }

        // POST: Tblilans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tblilans == null)
            {
                return Problem("Entity set 'DbjoblinqContext.Tblilans'  is null.");
            }
            var tblilan = await _context.Tblilans.FindAsync(id);
            if (tblilan != null)
            {
                _context.Tblilans.Remove(tblilan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblilanExists(int id)
        {
          return (_context.Tblilans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
