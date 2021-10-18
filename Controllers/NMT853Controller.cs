using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMT853.Models;

namespace nguyenminhtrong853.Controllers
{
    public class NMT853Controller : Controller
    {
        private readonly applicationContext _context;

        public NMT853Controller(applicationContext context)
        {
            _context = context;
        }

        // GET: NMT853
        public async Task<IActionResult> Index()
        {
            return View(await _context.NMT853.ToListAsync());
        }

        // GET: NMT853/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nMT853 = await _context.NMT853
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nMT853 == null)
            {
                return NotFound();
            }

            return View(nMT853);
        }

        // GET: NMT853/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NMT853/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] NMT853 nMT853)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nMT853);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nMT853);
        }

        // GET: NMT853/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nMT853 = await _context.NMT853.FindAsync(id);
            if (nMT853 == null)
            {
                return NotFound();
            }
            return View(nMT853);
        }

        // POST: NMT853/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] NMT853 nMT853)
        {
            if (id != nMT853.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nMT853);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NMT853Exists(nMT853.Id))
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
            return View(nMT853);
        }

        // GET: NMT853/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nMT853 = await _context.NMT853
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nMT853 == null)
            {
                return NotFound();
            }

            return View(nMT853);
        }

        // POST: NMT853/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nMT853 = await _context.NMT853.FindAsync(id);
            _context.NMT853.Remove(nMT853);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NMT853Exists(int id)
        {
            return _context.NMT853.Any(e => e.Id == id);
        }
    }
}
