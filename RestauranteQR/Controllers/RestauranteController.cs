using RestauranteQR.BaseDatos;
using System;
namespace RestauranteQR.Controllers
{
    public class RestauranteController
    {
        private readonly RestoDbContext _context;
        public RestauranteController(RestoDbContext context)
        {
            _context = context;
        }
    }
}
