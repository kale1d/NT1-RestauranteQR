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


            dbContext.SaveChanges();
            dbContext.Database.CommitTransaction();


        }
    }
}
