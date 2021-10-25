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

        public Ingrediente Ingrediente1 { get; set; }

        public Ingrediente Ingrediente2 { get; set; }

        public Plato()
        {
        }

        internal static ReadOnlySpan<char> FindFirstValue(string nameIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}
