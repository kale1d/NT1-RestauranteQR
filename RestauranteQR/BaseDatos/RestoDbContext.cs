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
        public DbSet<IngredientePorPlato> IngredientesPorPlatos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<RestauranteQR.Models.PlatosPorPedido> PlatosPorPedido { get; set; }
       
    }
}
