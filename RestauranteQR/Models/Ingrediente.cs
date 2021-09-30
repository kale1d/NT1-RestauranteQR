using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteQR.Models
{
   // [Table("INGREDIENTES")]
    public class Ingrediente
    {
        [Key]
        public int Id { get; set; }

        public String Nombre { get; set; }

        //[Display(Cantidad = "Qdad")]
        public int Cantidad { get; set; }
    }
}
