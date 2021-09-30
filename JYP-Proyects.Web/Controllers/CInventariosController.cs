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
    public class CInventariosController : Controller
    {
        private readonly DataContext _context;

        public CInventariosController(DataContext context)
        {
            _context = context;
        }

        // GET: CInventarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.CInventarios.ToListAsync());
        }

        // GET: CInventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cInventario = await _context.CInventarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cInventario == null)
            {
                return NotFound();
            }

            return View(cInventario);
        }

        // GET: CInventarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CInventarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CantidadAutos")] CInventario cInventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cInventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cInventario);
        }

        // GET: CInventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cInventario = await _context.CInventarios.FindAsync(id);
            if (cInventario == null)
            {
                return NotFound();
            }
            return View(cInventario);
        }

        // POST: CInventarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CantidadAutos")] CInventario cInventario)
        {
            if (id != cInventario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cInventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CInventarioExists(cInventario.Id))
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
            return View(cInventario);
        }

        // GET: CInventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cInventario = await _context.CInventarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cInventario == null)
            {
                return NotFound();
            }

            return View(cInventario);
        }

        // POST: CInventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cInventario = await _context.CInventarios.FindAsync(id);
            _context.CInventarios.Remove(cInventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CInventarioExists(int id)
        {
            return _context.CInventarios.Any(e => e.Id == id);
        }
    }
}
