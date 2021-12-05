using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.Models
{

    public class Plato
    {
        [Key]
        public int Id { get; set; }

        public String Nombre { get; set; }

        public int Precio { get; set; }

        
        public List<IngredientePlato> IngredientePlatos { get; set; }

        public int cantMax { get; set; }

        public Plato()
        {
            IngredientePlatos = new List<IngredientePlato>();
        }

        internal static ReadOnlySpan<char> FindFirstValue(string nameIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}
