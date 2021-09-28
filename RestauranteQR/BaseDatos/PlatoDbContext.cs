using Microsoft.EntityFrameworkCore;
using RestauranteQR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.BaseDatos
{
    public class PlatoDbContext : DbContext
    {
        public PlatoDbContext(DbContextOptions opciones) : base(opciones)
        {

        }
        public DbSet<Ingrediente> Ingredientes { get; set; }
    }
}
