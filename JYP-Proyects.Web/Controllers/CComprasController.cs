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
    public class CComprasController : Controller
    {
        private readonly DataContext _context;

        public CComprasController(DataContext context)
        {
            _context = context;
        }

        // GET: CCompras
        public async Task<IActionResult> Index()
        {
            return View(await _context.CCompras.ToListAsync());
        }

        // GET: CCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCompra = await _context.CCompras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cCompra == null)
            {
                return NotFound();
            }

            return View(cCompra);
        }

        // GET: CCompras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaC,DescripcionC,CostoC")] CCompra cCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cCompra);
        }

        // GET: CCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCompra = await _context.CCompras.FindAsync(id);
            if (cCompra == null)
            {
                return NotFound();
            }
            return View(cCompra);
        }

        // POST: CCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaC,DescripcionC,CostoC")] CCompra cCompra)
        {
            if (id != cCompra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CCompraExists(cCompra.Id))
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
            return View(cCompra);
        }

        // GET: CCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCompra = await _context.CCompras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cCompra == null)
            {
                return NotFound();
            }

            return View(cCompra);
        }

        // POST: CCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cCompra = await _context.CCompras.FindAsync(id);
            _context.CCompras.Remove(cCompra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CCompraExists(int id)
        {
            return _context.CCompras.Any(e => e.Id == id);
        }
    }
}
