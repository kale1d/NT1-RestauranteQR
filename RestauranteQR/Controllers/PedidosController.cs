using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteQR.BaseDatos;
using RestauranteQR.Models;
using RestauranteQR.ViewModel;

namespace RestauranteQR.Controllers
{
    public class PedidosController : Controller
    {

        private readonly RestoDbContext _context;

        public PedidosController(RestoDbContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
              var restoDbContext = _context.Pedidos;
            return View(await restoDbContext.ToListAsync());
        }
      

        // GET: Pedidos/Details/5
        //recibir el id del pedido y buscar el pedido, en la tabla platos por pedido buscar el id de los platos y en platos
        //buscar el nombre y el precio (sumar el precio de cada plato e informar el total)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
                var platosPorPedido = _context.PlatosPorPedido.ToList();
                var platos = _context.Platos;
                var total = 0.00;
            

            List<PlatosPorPedido> platosEnc = new List<PlatosPorPedido>();
               
                foreach (var pp in platosPorPedido)
                {

                    if (pp.PedidoId == id)
                    {
                        foreach (var pla in platos)
                        {
                            if (pp.PlatoId == pla.Id)
                            {
                                pp.NombrePlato = pla.Nombre;
                                pp.PrecioPlato = pla.Precio;
                                platosEnc.Add(pp);
                                total += (pp.PrecioPlato * pp.Cantidad);

                            }
                        }
                    }
                }

      
            ViewData["total"] = total;
            return View(platosEnc);
           
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["MesaId"] = new SelectList(_context.Mesa, "Id", "Id");
            ViewModel.VMPedido modelo = new ViewModel.VMPedido();
            modelo.ListaVMPedidoItem = new List<PlatosPorPedido>();
            foreach (var item in _context.Platos.ToList())
            {
                modelo.ListaVMPedidoItem.Add(new PlatosPorPedido()
                {
                    PlatoId = item.Id,
                    NombrePlato = item.Nombre,
                    PrecioPlato = item.Precio,
                    Cantidad = 0,
                }) ;
            }
            return View(modelo);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VMPedido pedido) 
        {

            if (ModelState.IsValid)
            {
               
                RNPedido.AgregarPedido(_context, pedido); 
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", new { id = pedido.Id}); 
            }

            else
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                 var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                
            }

            ViewData["MesaId"] = new SelectList(_context.Mesa, "Id", "Id", pedido.MesaId);
            return View(pedido);
       
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
  
            return RedirectToAction(nameof(Details));
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MesaId")] VMPedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    RNPedido.AgregarPedido(_context, pedido);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details));
            }
            ViewData["MesaId"] = new SelectList(_context.Mesa, "Id", "Id", pedido.MesaId);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.MesaId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
