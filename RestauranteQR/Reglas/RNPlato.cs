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
            
            foreach(var item in stringValues)
            {
              
                var ingId = Convert.ToInt32(item);
                var ingredi = dbContext.Ingredientes.ToList(); 
                var encontrado = false;
                int i = 0;
                while (!encontrado && i < ingredi.Count) //DE ESTA FORMA ME FIJO QUE SI EL INGREDIENTE QUE VINO POR PARAME ESTA EN LA LISTA DE INGREDIENTES DE LA BASE, LA AGREGO AL NUEVO PLATO COMO INGREDIENTEPLATOS
                {
                    if(ingredi[i].Id == ingId)
                    {
                        var ing = new IngredientePlato() { PlatoId = nuevoPlato.Id, IngredienteId = ingId, ElIngrediente = ingredi[i], ElPlato = nuevoPlato };
                        dbContext.IngredientePlato.Add(ing);

                        nuevoPlato.IngredientePlatos.Add(ing); 
                        encontrado = true;
                        dbContext.SaveChanges();
                    }
                    else { 
                        i++; 
                    }
                    
                }
          
                
            }
            
            dbContext.Database.CommitTransaction();

        }

        public static void ModificarPlato(RestoDbContext dbContext, int id, string nombre, int precio, StringValues stringValues, StringValues stringId, StringValues stringNombre)
        {
            dbContext.Database.BeginTransaction();
            Plato nuevoPlato = new Plato();
            nuevoPlato.Id = id;
            nuevoPlato.Nombre = nombre;
            nuevoPlato.Precio = precio;
           


            dbContext.Platos.Add(nuevoPlato);


            dbContext.SaveChanges();
            foreach (var item in stringValues)
            {

                var ingId = Convert.ToInt32(item);
                var ingredi = dbContext.Ingredientes.ToList();
                var encontrado = false;
                int i = 0;
                while (!encontrado && i < ingredi.Count) //DE ESTA FORMA ME FIJO QUE SI EL INGREDIENTE QUE VINO POR PARAME ESTA EN LA LISTA DE INGREDIENTES DE LA BASE, LA AGREGO AL NUEVO PLATO COMO INGREDIENTEPLATOS
                {
                    if (ingredi[i].Id == ingId)
                    {
                        var ing = new IngredientePlato() { PlatoId = nuevoPlato.Id, IngredienteId = ingId, ElIngrediente = ingredi[i], ElPlato = nuevoPlato };
                        dbContext.IngredientePlato.Add(ing);

                        nuevoPlato.IngredientePlatos.Add(ing);
                        encontrado = true;
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        i++;
                    }

                }


            }
            dbContext.Database.CommitTransaction();


        }

    }
}
