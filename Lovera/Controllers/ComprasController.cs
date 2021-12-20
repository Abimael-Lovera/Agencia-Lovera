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
    public class ComprasController : Controller
    {
        private readonly AgenciaContext _context;

        public ComprasController(AgenciaContext context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            var agenciaContext = _context.Compras.Include(c => c.IdPacoteNavigation).Include(c => c.IdPromoNavigation).Include(c => c.IdUserNavigation);
            return View(await agenciaContext.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.IdPacoteNavigation)
                .Include(c => c.IdPromoNavigation)
                .Include(c => c.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewData["IdPacote"] = new SelectList(_context.Pacotes, "IdPacote", "Description");
            ViewData["IdPromo"] = new SelectList(_context.Promos, "IdPromo", "Descripcao");
            ViewData["IdUser"] = new SelectList(_context.Usuarios, "IdUser", "Cidade");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompra,IdUser,IdPacote,IdPromo")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPacote"] = new SelectList(_context.Pacotes, "IdPacote", "Description", compra.IdPacote);
            ViewData["IdPromo"] = new SelectList(_context.Promos, "IdPromo", "Descripcao", compra.IdPromo);
            ViewData["IdUser"] = new SelectList(_context.Usuarios, "IdUser", "Cidade", compra.IdUser);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["IdPacote"] = new SelectList(_context.Pacotes, "IdPacote", "Description", compra.IdPacote);
            ViewData["IdPromo"] = new SelectList(_context.Promos, "IdPromo", "Descripcao", compra.IdPromo);
            ViewData["IdUser"] = new SelectList(_context.Usuarios, "IdUser", "Cidade", compra.IdUser);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompra,IdUser,IdPacote,IdPromo")] Compra compra)
        {
            if (id != compra.IdCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.IdCompra))
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
            ViewData["IdPacote"] = new SelectList(_context.Pacotes, "IdPacote", "Description", compra.IdPacote);
            ViewData["IdPromo"] = new SelectList(_context.Promos, "IdPromo", "Descripcao", compra.IdPromo);
            ViewData["IdUser"] = new SelectList(_context.Usuarios, "IdUser", "Cidade", compra.IdUser);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.IdPacoteNavigation)
                .Include(c => c.IdPromoNavigation)
                .Include(c => c.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
            return _context.Compras.Any(e => e.IdCompra == id);
        }
    }
}
