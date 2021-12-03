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

        [Display(Name = "Ingrediente 1")]
        public int? IngredienteId1 { get; set; }

        [Display(Name = "Ingrediente 2")]
        public int? IngredienteId2 { get; set; }

       // public virtual ICollection<Ingrediente> Ingredientes { get; set; }

        public ICollection<IngredientePlato> IngredientePlatos { get; set; }



        public Plato()
        {
           // Ingredientes = new List<Ingrediente>();
        }

        internal static ReadOnlySpan<char> FindFirstValue(string nameIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}
