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
    public class CProveedorsController : Controller
    {
        private readonly DataContext _context;

        public CProveedorsController(DataContext context)
        {
            _context = context;
        }

        // GET: CProveedors
        public async Task<IActionResult> Index()
        {
            return View(await _context.CProveedores.ToListAsync());
        }

        // GET: CProveedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cProveedor = await _context.CProveedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cProveedor == null)
            {
                return NotFound();
            }

            return View(cProveedor);
        }

        // GET: CProveedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CProveedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] CProveedor cProveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cProveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cProveedor);
        }

        // GET: CProveedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cProveedor = await _context.CProveedores.FindAsync(id);
            if (cProveedor == null)
            {
                return NotFound();
            }
            return View(cProveedor);
        }

        // POST: CProveedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] CProveedor cProveedor)
        {
            if (id != cProveedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cProveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CProveedorExists(cProveedor.Id))
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
            return View(cProveedor);
        }

        // GET: CProveedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cProveedor = await _context.CProveedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cProveedor == null)
            {
                return NotFound();
            }

            return View(cProveedor);
        }

        // POST: CProveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cProveedor = await _context.CProveedores.FindAsync(id);
            _context.CProveedores.Remove(cProveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CProveedorExists(int id)
        {
            return _context.CProveedores.Any(e => e.Id == id);
        }
    }
}
