using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.Models
{
    

    public class IngredientePorPlato
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Plato))]
        public int PlatoId { get; set; }

        [ForeignKey(nameof(Ingrediente))]
        public int IngredienteId { get; set; }

 

    }
}
