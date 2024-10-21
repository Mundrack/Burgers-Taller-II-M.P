using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MateoPugaProyectoII.Models;

namespace MateoPugaProyectoII.Controllers
{
    public class PromosController : Controller
    {
        private readonly MateoPugaDB _context;

        public PromosController(MateoPugaDB context)
        {
            _context = context;
        }

        // GET: Promos
        public async Task<IActionResult> Index()
        {
            var mateoPugaDB = _context.Promo.Include(p => p.Burger);
            return View(await mateoPugaDB.ToListAsync());
        }

        // GET: Promos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo
                .Include(p => p.Burger)
                .FirstOrDefaultAsync(m => m.PromoID == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // GET: Promos/Create
        public IActionResult Create()
        {
            ViewData["BurgerID"] = new SelectList(_context.Burger, "BurgerID", "BurgerID");
            return View();
        }

        // POST: Promos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromoID,Description,FechaPromo,BurgerID")] Promo promo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurgerID"] = new SelectList(_context.Burger, "BurgerID", "BurgerID", promo.BurgerID);
            return View(promo);
        }

        // GET: Promos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo.FindAsync(id);
            if (promo == null)
            {
                return NotFound();
            }
            ViewData["BurgerID"] = new SelectList(_context.Burger, "BurgerID", "BurgerID", promo.BurgerID);
            return View(promo);
        }

        // POST: Promos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromoID,Description,FechaPromo,BurgerID")] Promo promo)
        {
            if (id != promo.PromoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoExists(promo.PromoID))
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
            ViewData["BurgerID"] = new SelectList(_context.Burger, "BurgerID", "BurgerID", promo.BurgerID);
            return View(promo);
        }

        // GET: Promos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo
                .Include(p => p.Burger)
                .FirstOrDefaultAsync(m => m.PromoID == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // POST: Promos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promo = await _context.Promo.FindAsync(id);
            if (promo != null)
            {
                _context.Promo.Remove(promo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoExists(int id)
        {
            return _context.Promo.Any(e => e.PromoID == id);
        }
    }
}
