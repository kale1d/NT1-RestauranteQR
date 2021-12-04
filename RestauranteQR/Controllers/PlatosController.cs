﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteQR.BaseDatos;
using RestauranteQR.Models;
using RestauranteQR.ViewModel;

namespace RestauranteQR.Controllers
{
    //[Authorize(Roles = nameof(Rol.Administrador))]
    [Authorize]
    public class PlatosController : Controller
    {
        private readonly RestoDbContext _context;

        public PlatosController(RestoDbContext context)
        {
            _context = context;
        }

        // GET: Platos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Platos.ToListAsync());
        }

        // GET: Platos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var plato = await _context.Platos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plato == null)
            {
                return NotFound();
            }

            var ingredientes = _context.Ingredientes;
            

            for (int i = 0; i < ingredientes.ToList().Count; i++)// var ingrediente in ingredientes)
                {
                var ingreId = ingredientes.ToList()[i];
                for(int j = 0; j < plato.IngredientePlatos.ToList().Count; j++)
                {
                    var ingBusId = plato.IngredientePlatos.ToList()[j];
                
                    if (ingreId.Id == ingBusId.Id)
                    {
                        ViewData["Ingrediente1"] = ingreId.Nombre;
                    }
                }

            }

                //ESTO DE ABAJO ESTABA ANTES
                //foreach (var ingrediente in ingredientes)
                //{
                //    if (ingrediente.Id == plato.IngredienteId1)
                //    {
                //        ViewData["Ingrediente1"] = ingrediente.Nombre;
                //    }
                //    if (ingrediente.Id == plato.IngredienteId2) {
                //        ViewData["Ingrediente2"] = ingrediente.Nombre;
                //    }
                //}
                return View(plato);
        }

        // GET: Platos/Create
        public ActionResult Create()
        {
      

            
            Plato plato = new Plato();
            var ingredientes = _context.Ingredientes.ToList();
            //ViewData["IngredienteId1"] = new SelectList(ingredientes, "Id", "Nombre", plato.IngredienteId1);
            //ViewData["IngredienteId2"] = new SelectList(ingredientes, "Id", "Nombre", plato.IngredienteId2);
            ViewBag.Ingredientes = new SelectList(ingredientes, "Id", "Nombre");
            ViewBag.IngredientesList = ingredientes;

            return View();
        }

        // POST: Platos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Plato plato)
        {
            if (ModelState.IsValid)
            {
                RNPlato.AgregarPlato(_context, plato.Id, plato.Nombre, plato.Precio, Request.Form["ingredientesPorPlato"], Request.Form["ingredientesPorPlatoId"], Request.Form["ingredientesPorPlatoNombre"]);
                //_context.Add(plato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plato);
        }

        // GET: Platos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plato = await _context.Platos.FindAsync(id);
            if (plato == null)
            {
                return NotFound();
            }

            //Plato plato = new Plato();
            var ingredientes = _context.Ingredientes.ToList();
            //ViewData["IngredienteId1"] = new SelectList(ingredientes, "Id", "Nombre", plato.IngredienteId1);
            //ViewData["IngredienteId2"] = new SelectList(ingredientes, "Id", "Nombre", plato.IngredienteId2);
            ViewBag.Ingredientes = new SelectList(ingredientes, "Id", "Nombre");
            ViewBag.IngredientesList = ingredientes;
            //ViewBag.Ingredientes = ingredientes;


            return View(plato);
        }

        // POST: Platos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Plato plato)
        {
            if (id != plato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   
                    _context.Update(plato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatoExists(plato.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        RNPlato.ModificarPlato(_context, plato.Id, plato.Nombre, plato.Precio, Request.Form["ingredientesPorPlato"], Request.Form["ingredientesPorPlatoId"], Request.Form["ingredientesPorPlatoNombre"]);
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(plato);
        }

        // GET: Platos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plato = await _context.Platos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plato == null)
            {
                return NotFound();
            }

            return View(plato);
        }

        // POST: Platos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plato = await _context.Platos.FindAsync(id);
            _context.Platos.Remove(plato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatoExists(int id)
        {
            return _context.Platos.Any(e => e.Id == id);
        }
    }
}
