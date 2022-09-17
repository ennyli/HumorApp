using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HumorApp.Data;
using HumorApp.Models;

namespace HumorApp.Controllers
{
    public class GaaterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GaaterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gaater
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gaate_1.ToListAsync());
        }

        // GET: Gaater/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gaate = await _context.Gaate_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gaate == null)
            {
                return NotFound();
            }

            return View(gaate);
        }

        // GET: Gaater/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gaater/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GaateSporsmal,GaateSvar,Kategori")] Gaate gaate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gaate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gaate);
        }

        // GET: Gaater/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gaate = await _context.Gaate_1.FindAsync(id);
            if (gaate == null)
            {
                return NotFound();
            }
            return View(gaate);
        }

        // POST: Gaater/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GaateSporsmal,GaateSvar,Kategori")] Gaate gaate)
        {
            if (id != gaate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gaate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GaateExists(gaate.Id))
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
            return View(gaate);
        }

        // GET: Gaater/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gaate = await _context.Gaate_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gaate == null)
            {
                return NotFound();
            }

            return View(gaate);
        }

        // POST: Gaater/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gaate = await _context.Gaate_1.FindAsync(id);
            _context.Gaate_1.Remove(gaate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GaateExists(int id)
        {
            return _context.Gaate_1.Any(e => e.Id == id);
        }
    }
}
