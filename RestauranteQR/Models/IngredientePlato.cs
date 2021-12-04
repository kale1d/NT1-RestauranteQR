using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.Models
{
    

    public class IngredientePlato
    {

        [Key]
        public int Id { get; set; }




        [ForeignKey(nameof(Plato))]
        public int PlatoId { get; set; }

        public Plato ElPlato { get; set; }

        [ForeignKey(nameof(Ingrediente))]
        public int IngredienteId { get; set; }

        public Ingrediente ElIngrediente { get; set; }



    }
}
