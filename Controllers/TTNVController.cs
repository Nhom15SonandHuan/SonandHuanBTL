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
    public class TTNVController : Controller
    {
        private readonly ApplicationDbcontext _context;

        public TTNVController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: TTNV
        public async Task<IActionResult> Index()
        {
              return _context.TTNV != null ? 
                          View(await _context.TTNV.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TTNV'  is null.");
        }

        // GET: TTNV/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TTNV == null)
            {
                return NotFound();
            }

            var ttnv = await _context.TTNV
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ttnv == null)
            {
                return NotFound();
            }

            return View(ttnv);
        }

        // GET: TTNV/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TTNV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Age,Salary")] TTNV ttnv)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ttnv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ttnv);
        }

        // GET: TTNV/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TTNV == null)
            {
                return NotFound();
            }

            var ttnv = await _context.TTNV.FindAsync(id);
            if (ttnv == null)
            {
                return NotFound();
            }
            return View(ttnv);
        }

        // POST: TTNV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name,Age,Salary")] TTNV ttnv)
        {
            if (id != ttnv.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ttnv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TTNVExists(ttnv.ID))
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
            return View(ttnv);
        }

        // GET: TTNV/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TTNV == null)
            {
                return NotFound();
            }

            var ttnv = await _context.TTNV
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ttnv == null)
            {
                return NotFound();
            }

            return View(ttnv);
        }

        // POST: TTNV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TTNV == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TTNV'  is null.");
            }
            var ttnv = await _context.TTNV.FindAsync(id);
            if (ttnv != null)
            {
                _context.TTNV.Remove(ttnv);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TTNVExists(string id)
        {
          return (_context.TTNV?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}