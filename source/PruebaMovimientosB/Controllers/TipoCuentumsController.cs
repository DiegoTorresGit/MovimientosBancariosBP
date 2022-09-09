using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovimientosBancariosBP.transaccionalAPI;

namespace MovimientosBancariosBP.Controllers
{
    public class TipoCuentumsController : Controller
    {
        private readonly bd_movimientosContext _context = new bd_movimientosContext();

        //public TipoCuentumsController(bd_movimientosContext context)
        //{
        //    _context = context;
        //}

        // GET: TipoCuentums
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoCuenta.ToListAsync());
        }

        // GET: TipoCuentums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCuentum = await _context.TipoCuenta
                .FirstOrDefaultAsync(m => m.CodigoTc == id);
            if (tipoCuentum == null)
            {
                return NotFound();
            }

            return View(tipoCuentum);
        }

        // GET: TipoCuentums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoCuentums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoTc,CuentaTc,Estado")] TipoCuentum tipoCuentum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoCuentum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCuentum);
        }

        // GET: TipoCuentums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCuentum = await _context.TipoCuenta.FindAsync(id);
            if (tipoCuentum == null)
            {
                return NotFound();
            }
            return View(tipoCuentum);
        }

        // POST: TipoCuentums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoTc,CuentaTc,Estado")] TipoCuentum tipoCuentum)
        {
            if (id != tipoCuentum.CodigoTc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoCuentum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoCuentumExists(tipoCuentum.CodigoTc))
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
            return View(tipoCuentum);
        }

        // GET: TipoCuentums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCuentum = await _context.TipoCuenta
                .FirstOrDefaultAsync(m => m.CodigoTc == id);
            if (tipoCuentum == null)
            {
                return NotFound();
            }

            return View(tipoCuentum);
        }

        // POST: TipoCuentums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoCuentum = await _context.TipoCuenta.FindAsync(id);
            _context.TipoCuenta.Remove(tipoCuentum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoCuentumExists(int id)
        {
            return _context.TipoCuenta.Any(e => e.CodigoTc == id);
        }
    }
}
