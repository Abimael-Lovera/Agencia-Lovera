#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lovera.Models;

namespace Lovera.Controllers
{
    public class PromoesController : Controller
    {
        private readonly AgenciaContext _context;

        public PromoesController(AgenciaContext context)
        {
            _context = context;
        }

        // GET: Promoes
        public async Task<IActionResult> Index()
        {
            var agenciaContext = _context.Promos.Include(p => p.IdDestinoNavigation);
            return View(await agenciaContext.ToListAsync());
        }

        // GET: Promoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promos
                .Include(p => p.IdDestinoNavigation)
                .FirstOrDefaultAsync(m => m.IdPromo == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // GET: Promoes/Create
        public IActionResult Create()
        {
            ViewData["IdDestino"] = new SelectList(_context.Destinos, "IdDestino", "Descripcao");
            return View();
        }

        // POST: Promoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPromo,Nome,Descripcao,Preco,IdDestino")] Promo promo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDestino"] = new SelectList(_context.Destinos, "IdDestino", "Descripcao", promo.IdDestino);
            return View(promo);
        }

        // GET: Promoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promos.FindAsync(id);
            if (promo == null)
            {
                return NotFound();
            }
            ViewData["IdDestino"] = new SelectList(_context.Destinos, "IdDestino", "Descripcao", promo.IdDestino);
            return View(promo);
        }

        // POST: Promoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPromo,Nome,Descripcao,Preco,IdDestino")] Promo promo)
        {
            if (id != promo.IdPromo)
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
                    if (!PromoExists(promo.IdPromo))
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
            ViewData["IdDestino"] = new SelectList(_context.Destinos, "IdDestino", "Descripcao", promo.IdDestino);
            return View(promo);
        }

        // GET: Promoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promos
                .Include(p => p.IdDestinoNavigation)
                .FirstOrDefaultAsync(m => m.IdPromo == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // POST: Promoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promo = await _context.Promos.FindAsync(id);
            _context.Promos.Remove(promo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoExists(int id)
        {
            return _context.Promos.Any(e => e.IdPromo == id);
        }
    }
}
