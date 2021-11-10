using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteQR.BaseDatos;
using RestauranteQR.Models;

namespace RestauranteQR.Controllers
{
    public class PlatosPorPedidoController : Controller
    {
        private readonly RestoDbContext _context;

        public PlatosPorPedidoController(RestoDbContext context)
        {
            _context = context;
        }

        // GET: PlatosPorPedido
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlatosPorPedido.ToListAsync());
        }

        // GET: PlatosPorPedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platosPorPedido = await _context.PlatosPorPedido
                .FirstOrDefaultAsync(m => m.Id == id);
            if (platosPorPedido == null)
            {
                return NotFound();
            }

            return View(platosPorPedido);
        }

        // GET: PlatosPorPedido/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlatosPorPedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PedidoId,MesaId,PlatoId,Cantidad")] PlatosPorPedido platosPorPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(platosPorPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(platosPorPedido);
        }

        // GET: PlatosPorPedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platosPorPedido = await _context.PlatosPorPedido.FindAsync(id);
            if (platosPorPedido == null)
            {
                return NotFound();
            }
            return View(platosPorPedido);
        }

        // POST: PlatosPorPedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PedidoId,MesaId,PlatoId,Cantidad")] PlatosPorPedido platosPorPedido)
        {
            if (id != platosPorPedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(platosPorPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatosPorPedidoExists(platosPorPedido.Id))
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
            return View(platosPorPedido);
        }

        // GET: PlatosPorPedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platosPorPedido = await _context.PlatosPorPedido
                .FirstOrDefaultAsync(m => m.Id == id);
            if (platosPorPedido == null)
            {
                return NotFound();
            }

            return View(platosPorPedido);
        }

        // POST: PlatosPorPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var platosPorPedido = await _context.PlatosPorPedido.FindAsync(id);
            _context.PlatosPorPedido.Remove(platosPorPedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatosPorPedidoExists(int id)
        {
            return _context.PlatosPorPedido.Any(e => e.Id == id);
        }
    }
}
