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
        public DbSet<IngredientePlato> IngredientePlato { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<RestauranteQR.Models.PlatosPorPedido> PlatosPorPedido { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<IngredientePlato>()
        //        .HasKey(bc => new { bc.IngredienteId, bc.PlatoId });
        //    modelBuilder.Entity<IngredientePlato>()
        //        .HasOne(bc => bc.Ingrediente)
        //        .WithMany(b => b.Platos)
        //        .HasForeignKey(bc => bc.BookId);
        //    modelBuilder.Entity<IngredientePlato>()
        //        .HasOne(bc => bc.Plato)
        //        .WithMany(c => c.Ingredientes)
        //        .HasForeignKey(bc => bc.CategoryId);
        //}

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<IngredientePlato>()
               .HasKey(bc => new { bc.IngredienteId, bc.PlatoId });
           modelBuilder.Entity<IngredientePlato>()
               .HasOne(bc => bc.ElIngrediente)
               .WithMany(b => b.IngredientePlatos)
               .HasForeignKey(bc => bc.IngredienteId);
           modelBuilder.Entity<IngredientePlato>()
               .HasOne(bc => bc.ElPlato)
               .WithMany(c => c.IngredientePlatos)
               .HasForeignKey(bc => bc.PlatoId);
       }

    }
}
