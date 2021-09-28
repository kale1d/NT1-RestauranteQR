using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.BaseDatos
{
    public class IngredienteDbContext : DbContext
    {
        public IngredienteDbContext(DbContextOptions opciones) : base(opciones)
        {

        }
        
    }
}
