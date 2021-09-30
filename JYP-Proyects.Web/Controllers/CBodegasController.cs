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
    public class CBodegasController : Controller
    {
        private readonly DataContext _context;

        public CBodegasController(DataContext context)
        {
            _context = context;
        }

        // GET: CBodegas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CBodegas.ToListAsync());
        }

        // GET: CBodegas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cBodega = await _context.CBodegas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cBodega == null)
            {
                return NotFound();
            }

            return View(cBodega);
        }

        // GET: CBodegas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CBodegas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cupo,Descripcion")] CBodega cBodega)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cBodega);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cBodega);
        }

        // GET: CBodegas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cBodega = await _context.CBodegas.FindAsync(id);
            if (cBodega == null)
            {
                return NotFound();
            }
            return View(cBodega);
        }

        // POST: CBodegas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cupo,Descripcion")] CBodega cBodega)
        {
            if (id != cBodega.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cBodega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CBodegaExists(cBodega.Id))
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
            return View(cBodega);
        }

        // GET: CBodegas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cBodega = await _context.CBodegas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cBodega == null)
            {
                return NotFound();
            }

            return View(cBodega);
        }

        // POST: CBodegas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cBodega = await _context.CBodegas.FindAsync(id);
            _context.CBodegas.Remove(cBodega);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CBodegaExists(int id)
        {
            return _context.CBodegas.Any(e => e.Id == id);
        }
    }
}
