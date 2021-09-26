using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.Models
{
   // [Table("INGREDIENTES")]
    public class Ingrediente
    {
   //     [Key]
        public int Id { get; set; }

        public String Nombre { get; set; }

        public int Cantidad { get; set; }
    }
}
