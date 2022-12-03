using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom15.Data;
using Nhom15.Models;

namespace Nhom15.Controllers
{
    public class TTDCControllers : Controller
    {
        private readonly ApplicationDbcontext _context;

        public TTDCControllers(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: TTDC
        public async Task<IActionResult> Index()
        {
              return _context.TTDC != null ? 
                          View(await _context.TTDC.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TTDC'  is null.");
        }

        // GET: TTDC/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TTDC == null)
            {
                return NotFound();
            }

            var ttdc = await _context.TTDC
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ttdc == null)
            {
                return NotFound();
            }

            return View(ttdc);
        }

        // GET: TTDC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TTDC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Number,Status")] TTDC ttdc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ttdc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ttdc);
        }

        // GET: TTDC/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TTDC == null)
            {
                return NotFound();
            }

            var ttdc = await _context.TTDC.FindAsync(id);
            if (ttdc == null)
            {
                return NotFound();
            }
            return View(ttdc);
        }

        // POST: TTDC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name,Number,Status")] TTDC ttdc)
        {
            if (id != ttdc.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ttdc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TTDCExists(ttdc.ID))
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
            return View(ttdc);
        }

        // GET: TTDC/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TTDC == null)
            {
                return NotFound();
            }

            var ttdc = await _context.TTDC
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ttdc == null)
            {
                return NotFound();
            }

            return View(ttdc);
        }

        // POST: TTDC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TTDC == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TTDC'  is null.");
            }
            var ttdc = await _context.TTDC.FindAsync(id);
            if (ttdc != null)
            {
                _context.TTDC.Remove(ttdc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TTDCExists(string id)
        {
          return (_context.TTDC?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}