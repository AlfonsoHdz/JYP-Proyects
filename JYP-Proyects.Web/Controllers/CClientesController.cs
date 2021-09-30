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
    public class CClientesController : Controller
    {
        private readonly DataContext _context;

        public CClientesController(DataContext context)
        {
            _context = context;
        }

        // GET: CClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CClientes.ToListAsync());
        }

        // GET: CClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCliente = await _context.CClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cCliente == null)
            {
                return NotFound();
            }

            return View(cCliente);
        }

        // GET: CClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] CCliente cCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cCliente);
        }

        // GET: CClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCliente = await _context.CClientes.FindAsync(id);
            if (cCliente == null)
            {
                return NotFound();
            }
            return View(cCliente);
        }

        // POST: CClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] CCliente cCliente)
        {
            if (id != cCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CClienteExists(cCliente.Id))
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
            return View(cCliente);
        }

        // GET: CClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCliente = await _context.CClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cCliente == null)
            {
                return NotFound();
            }

            return View(cCliente);
        }

        // POST: CClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cCliente = await _context.CClientes.FindAsync(id);
            _context.CClientes.Remove(cCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CClienteExists(int id)
        {
            return _context.CClientes.Any(e => e.Id == id);
        }
    }
}
