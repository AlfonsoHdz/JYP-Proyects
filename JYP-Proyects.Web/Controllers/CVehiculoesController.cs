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
    public class CVehiculoesController : Controller
    {
        private readonly DataContext _context;

        public CVehiculoesController(DataContext context)
        {
            _context = context;
        }

        // GET: CVehiculoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CVehiculos.ToListAsync());
        }

        // GET: CVehiculoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVehiculo = await _context.CVehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cVehiculo == null)
            {
                return NotFound();
            }

            return View(cVehiculo);
        }

        // GET: CVehiculoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CVehiculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,DescripcionV,Año,Precio")] CVehiculo cVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cVehiculo);
        }

        // GET: CVehiculoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVehiculo = await _context.CVehiculos.FindAsync(id);
            if (cVehiculo == null)
            {
                return NotFound();
            }
            return View(cVehiculo);
        }

        // POST: CVehiculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,DescripcionV,Año,Precio")] CVehiculo cVehiculo)
        {
            if (id != cVehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cVehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CVehiculoExists(cVehiculo.Id))
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
            return View(cVehiculo);
        }

        // GET: CVehiculoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVehiculo = await _context.CVehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cVehiculo == null)
            {
                return NotFound();
            }

            return View(cVehiculo);
        }

        // POST: CVehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cVehiculo = await _context.CVehiculos.FindAsync(id);
            _context.CVehiculos.Remove(cVehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CVehiculoExists(int id)
        {
            return _context.CVehiculos.Any(e => e.Id == id);
        }
    }
}
