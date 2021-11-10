using RestauranteQR.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.Models
{
    public class RNPlato
    {

        public static void AgregarPlato(RestoDbContext dbContext, int id, string nombre, int precio, int? ingrediente1, int? ingrediente2)
        {
            dbContext.Database.BeginTransaction();
            Plato nuevoPlato = new Plato();
            nuevoPlato.Id = id;
            nuevoPlato.Nombre = nombre;
            nuevoPlato.Precio = precio;
            nuevoPlato.IngredienteId1 = ingrediente1;
            nuevoPlato.IngredienteId2 = ingrediente2;

            dbContext.Platos.Add(nuevoPlato);

            //IngredientePorPlato ingrePorPlato1 = new IngredientePorPlato();
            //IngredientePorPlato ingrePorPlato2 = new IngredientePorPlato();

            //ingrePorPlato1.PlatoId = nuevoPlato.Id;
            //ingrePorPlato2.PlatoId = nuevoPlato.Id;

            //ingrePorPlato1.IngredienteId = ingrediente1.Id;
            //ingrePorPlato2.IngredienteId = ingrediente2.Id;

            //dbContext.IngredientesPorPlatos.Add(ingrePorPlato1);
            //dbContext.IngredientesPorPlatos.Add(ingrePorPlato2);

            dbContext.SaveChanges();
            dbContext.Database.CommitTransaction();


        }

        public static void ModificarPlato(RestoDbContext dbContext, int id, string nombre, int precio, int? ingrediente1, int? ingrediente2)
        {
            dbContext.Database.BeginTransaction();
            Plato nuevoPlato = new Plato();
            nuevoPlato.Id = id;
            nuevoPlato.Nombre = nombre;
            nuevoPlato.Precio = precio;
            nuevoPlato.IngredienteId1 = ingrediente1;
            nuevoPlato.IngredienteId2 = ingrediente2;

            dbContext.Platos.Add(nuevoPlato);

            //IngredientePorPlato ingrePorPlato1 = new IngredientePorPlato();
            //IngredientePorPlato ingrePorPlato2 = new IngredientePorPlato();

            //ingrePorPlato1.PlatoId = nuevoPlato.Id;
            //ingrePorPlato2.PlatoId = nuevoPlato.Id;

            //ingrePorPlato1.IngredienteId = ingrediente1.Id;
            //ingrePorPlato2.IngredienteId = ingrediente2.Id;

            //dbContext.IngredientesPorPlatos.Add(ingrePorPlato1);
            //dbContext.IngredientesPorPlatos.Add(ingrePorPlato2);

            dbContext.SaveChanges();
            dbContext.Database.CommitTransaction();


        }
    }
}
