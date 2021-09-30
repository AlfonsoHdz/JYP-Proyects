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
    public class CVentasController : Controller
    {
        private readonly DataContext _context;

        public CVentasController(DataContext context)
        {
            _context = context;
        }

        // GET: CVentas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CVentas.ToListAsync());
        }

        // GET: CVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVenta = await _context.CVentas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cVenta == null)
            {
                return NotFound();
            }

            return View(cVenta);
        }

        // GET: CVentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaV,DescripcionV,CostoV")] CVenta cVenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cVenta);
        }

        // GET: CVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVenta = await _context.CVentas.FindAsync(id);
            if (cVenta == null)
            {
                return NotFound();
            }
            return View(cVenta);
        }

        // POST: CVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaV,DescripcionV,CostoV")] CVenta cVenta)
        {
            if (id != cVenta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CVentaExists(cVenta.Id))
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
            return View(cVenta);
        }

        // GET: CVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVenta = await _context.CVentas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cVenta == null)
            {
                return NotFound();
            }

            return View(cVenta);
        }

        // POST: CVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cVenta = await _context.CVentas.FindAsync(id);
            _context.CVentas.Remove(cVenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CVentaExists(int id)
        {
            return _context.CVentas.Any(e => e.Id == id);
        }
    }
}
