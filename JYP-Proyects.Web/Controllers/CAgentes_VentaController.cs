using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JYP_Proyects.Web.Data;
using JYP_Proyects.Web.Data.Entities;

namespace JYP_Proyects.Web.Controllers
{
    public class CAgentes_VentaController : Controller
    {
        private readonly DataContext _context;

        public CAgentes_VentaController(DataContext context)
        {
            _context = context;
        }

        // GET: CAgentes_Venta
        public async Task<IActionResult> Index()
        {
            return View(await _context.CAgentes_Ventas
                .Include(t => t.User)
                .ToListAsync());
        }

        // GET: CAgentes_Venta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cAgentes_Venta = await _context.CAgentes_Ventas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cAgentes_Venta == null)
            {
                return NotFound();
            }

            return View(cAgentes_Venta);
        }

        // GET: CAgentes_Venta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CAgentes_Venta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] CAgentes_Venta cAgentes_Venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cAgentes_Venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cAgentes_Venta);
        }

        // GET: CAgentes_Venta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cAgentes_Venta = await _context.CAgentes_Ventas.FindAsync(id);
            if (cAgentes_Venta == null)
            {
                return NotFound();
            }
            return View(cAgentes_Venta);
        }

        // POST: CAgentes_Venta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] CAgentes_Venta cAgentes_Venta)
        {
            if (id != cAgentes_Venta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cAgentes_Venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CAgentes_VentaExists(cAgentes_Venta.Id))
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
            return View(cAgentes_Venta);
        }

        // GET: CAgentes_Venta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cAgentes_Venta = await _context.CAgentes_Ventas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cAgentes_Venta == null)
            {
                return NotFound();
            }

            return View(cAgentes_Venta);
        }

        // POST: CAgentes_Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cAgentes_Venta = await _context.CAgentes_Ventas.FindAsync(id);
            _context.CAgentes_Ventas.Remove(cAgentes_Venta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CAgentes_VentaExists(int id)
        {
            return _context.CAgentes_Ventas.Any(e => e.Id == id);
        }
    }
}
