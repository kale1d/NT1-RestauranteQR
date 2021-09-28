using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.Models
{
    
    public class Plato
    {
        private string nombre;
        private List<Ingrediente> ingredientesDelPlato;
        public Plato(string nombre)
        {
            ingredientesDelPlato = new List<Ingrediente>();
        }

        private void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        
    }
}
