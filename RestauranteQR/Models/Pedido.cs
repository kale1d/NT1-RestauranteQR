using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteQR.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Mesa))]
        public int MesaId { get; set; }

        [ForeignKey("MesaId")]
        public virtual Mesa Mesa { get; set; }



        public Pedido()
        {
        }
    }
}
