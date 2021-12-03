using Microsoft.Extensions.Primitives;
using RestauranteQR.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.Models
{
    public class RNPlato
    {

        public static void AgregarPlato(RestoDbContext dbContext, int id, string nombre, int precio, StringValues stringValues, StringValues stringId, StringValues stringNombre)
        {
            dbContext.Database.BeginTransaction();
            Plato nuevoPlato = new Plato();
            nuevoPlato.Id = id;
            nuevoPlato.Nombre = nombre;
            nuevoPlato.Precio = precio;
            

           


            dbContext.Platos.Add(nuevoPlato);


            dbContext.SaveChanges();
            //HACER EL FOREACH DE 
            foreach(var item in stringValues)
            {
                //EN EL PTRO LADO
                Ingrediente ingActual = dbContext.Ingredientes.Single(x => x.Id == Convert.ToInt32(item));
                dbContext.IngredientePlato.Add(new IngredientePlato() { PlatoId = nuevoPlato.Id, IngredienteId = Convert.ToInt32(item) });
            }
            
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


            dbContext.SaveChanges();
            dbContext.Database.CommitTransaction();


        }

    }
}
