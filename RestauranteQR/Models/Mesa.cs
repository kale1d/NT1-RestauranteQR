using System;
using System.ComponentModel.DataAnnotations;

namespace RestauranteQR.Models
{
    public class Mesa
    {
        [Key]
        public int Id { get; set; }

        public String Nombre { get; set; }

        public int Activo { get; set; }

        public Mesa()
        {
            
        }
    }
}
