using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestauranteQR.BaseDatos;
using RestauranteQR.Models;

namespace RestauranteQR.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestoDbContext _context;

        public HomeController(RestoDbContext context)
        {
            _context = context;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
           //Plato pla = new Plato();
           //pla.Nombre = "toronja con tuco";
           //pla.Ingredientes.Add(new Ingrediente() { Nombre = "a", Cantidad = 3 });
           //pla.Ingredientes.Add(new Ingrediente() { Nombre = "b", Cantidad = 14 });
           //pla.Ingredientes.Add(new Ingrediente() { Nombre = "c", Cantidad = 2 });
           //_context.Platos.Add(pla);
           //_context.SaveChanges();
            return View();
        }

        public IActionResult Carta()
        {
            return View(_context.Platos.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
