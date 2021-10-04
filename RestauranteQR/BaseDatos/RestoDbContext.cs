using Microsoft.EntityFrameworkCore;
using RestauranteQR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.BaseDatos
{
    public class RestoDbContext : DbContext
    {
        public RestoDbContext(DbContextOptions opciones) : base(opciones)
        {

        }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Plato> Platos { get; set; }

        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<IngredientePorPlato> IngredientePorPlatos { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<RestauranteQR.Models.Usuario> Usuario { get; set; }

    }
}
