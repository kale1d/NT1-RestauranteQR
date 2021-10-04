using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        public String Nombre { get; set; }

        public String Apellido { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public Usuario()
        {

        }
    }
}
