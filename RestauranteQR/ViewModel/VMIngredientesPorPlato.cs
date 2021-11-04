using RestauranteQR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.ViewModel
{
    public class VMIngredientesPorPlato
    {
          public List<Ingrediente> Ingredientes { get; set; }

          public Plato Plato { get; set; }

        public int? Ingrediente1Id { get; set; }

    }
}
