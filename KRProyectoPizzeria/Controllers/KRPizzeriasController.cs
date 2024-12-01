using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KRProyectoPizzeria.Models;

namespace KRProyectoPizzeria.Controllers
{
    public class KRPizzeriasController : Controller
    {
        private readonly KRProyectoPizzeriaContext _context;

        public KRPizzeriasController(KRProyectoPizzeriaContext context)
        {
            _context = context;
        }

        // GET: KRPizzerias
        public async Task<IActionResult> Index()
        {
            return View(await _context.KRPizzeria.ToListAsync());
        }

        // GET: KRPizzerias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kRPizzeria = await _context.KRPizzeria
                .FirstOrDefaultAsync(m => m.idKRPizzeria == id);
            if (kRPizzeria == null)
            {
                return NotFound();
            }

            return View(kRPizzeria);
        }

        // GET: KRPizzerias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KRPizzerias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idKRPizzeria,KR_Name,KR_WithCocaCola,KR_Precio")] KRPizzeria kRPizzeria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kRPizzeria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kRPizzeria);
        }

        // GET: KRPizzerias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kRPizzeria = await _context.KRPizzeria.FindAsync(id);
            if (kRPizzeria == null)
            {
                return NotFound();
            }
            return View(kRPizzeria);
        }

        // POST: KRPizzerias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idKRPizzeria,KR_Name,KR_WithCocaCola,KR_Precio")] KRPizzeria kRPizzeria)
        {
            if (id != kRPizzeria.idKRPizzeria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kRPizzeria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KRPizzeriaExists(kRPizzeria.idKRPizzeria))
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
            return View(kRPizzeria);
        }

        // GET: KRPizzerias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kRPizzeria = await _context.KRPizzeria
                .FirstOrDefaultAsync(m => m.idKRPizzeria == id);
            if (kRPizzeria == null)
            {
                return NotFound();
            }

            return View(kRPizzeria);
        }

        // POST: KRPizzerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kRPizzeria = await _context.KRPizzeria.FindAsync(id);
            if (kRPizzeria != null)
            {
                _context.KRPizzeria.Remove(kRPizzeria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KRPizzeriaExists(int id)
        {
            return _context.KRPizzeria.Any(e => e.idKRPizzeria == id);
        }
    }
}
