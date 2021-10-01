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
    public class CAgenciasController : Controller
    {
        private readonly DataContext _context;

        public CAgenciasController(DataContext context)
        {
            _context = context;
        }

        // GET: CAgencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.CAgencias.ToListAsync());
        }

        // GET: CAgencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cAgencia = await _context.CAgencias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cAgencia == null)
            {
                return NotFound();
            }

            return View(cAgencia);
        }

        // GET: CAgencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CAgencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //[Bind("Id,Nombre,Descripcion,Direccion,Telefono,Correo")]
        public async Task<IActionResult> Create(CAgencia cAgencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cAgencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cAgencia);
        }

        // GET: CAgencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cAgencia = await _context.CAgencias.FindAsync(id);
            if (cAgencia == null)
            {
                return NotFound();
            }
            return View(cAgencia);
        }

        // POST: CAgencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Direccion,Telefono,Correo")] CAgencia cAgencia)
        {
            if (id != cAgencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cAgencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CAgenciaExists(cAgencia.Id))
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
            return View(cAgencia);
        }

        // GET: CAgencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cAgencia = await _context.CAgencias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cAgencia == null)
            {
                return NotFound();
            }

            return View(cAgencia);
        }

        // POST: CAgencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cAgencia = await _context.CAgencias.FindAsync(id);
            _context.CAgencias.Remove(cAgencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CAgenciaExists(int id)
        {
            return _context.CAgencias.Any(e => e.Id == id);
        }
    }
}
