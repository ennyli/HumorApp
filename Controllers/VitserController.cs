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
    public class VitserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VitserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vitser
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vits_1.ToListAsync());
        }

        // GET: Vitser/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // GET: Vitser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vits = await _context.Vits_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vits == null)
            {
                return NotFound();
            }

            return View(vits);
        }

        // GET: Vitser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vitser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vitsen,Kategori")] Vits vits)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vits);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vits);
        }

        // GET: Vitser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vits = await _context.Vits_1.FindAsync(id);
            if (vits == null)
            {
                return NotFound();
            }
            return View(vits);
        }

        // POST: Vitser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Vitsen,Kategori")] Vits vits)
        {
            if (id != vits.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vits);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VitsExists(vits.Id))
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
            return View(vits);
        }

        // GET: Vitser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vits = await _context.Vits_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vits == null)
            {
                return NotFound();
            }

            return View(vits);
        }

        // POST: Vitser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vits = await _context.Vits_1.FindAsync(id);
            _context.Vits_1.Remove(vits);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VitsExists(int id)
        {
            return _context.Vits_1.Any(e => e.Id == id);
        }
    }
}
