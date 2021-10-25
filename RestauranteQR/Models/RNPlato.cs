using RestauranteQR.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.Models
{
    public class RNPlato
    {

        public static void AgregarPlato(RestoDbContext dbContext, int id, string nombre, int precio, string ingrediente1, string ingrediente2)
        {
            dbContext.Database.BeginTransaction();
            Plato nuevoPlato = new Plato();
            nuevoPlato.Id = id;
            nuevoPlato.Nombre = nombre;
            nuevoPlato.Precio = precio;
            nuevoPlato.Ingrediente1 = ingrediente1;
            nuevoPlato.Ingrediente2 = ingrediente2;

            dbContext.Platos.Add(nuevoPlato);

            IngredientePorPlato ingre1 = new IngredientePorPlato();
            IngredientePorPlato ingre2 = new IngredientePorPlato();

            dbContext.IngredientesPorPlatos.Add(ingre1);
            dbContext.IngredientesPorPlatos.Add(ingre2);

            dbContext.SaveChanges();
            dbContext.Database.CommitTransaction();


        }
    }
}
