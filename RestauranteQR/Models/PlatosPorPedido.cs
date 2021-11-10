using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.Models
{
    public class PlatosPorPedido
    {
        public int Id { get; set; }
        public string NombrePlato { get; set; }
        public double PrecioPlato { get; set; }
        public int PedidoId { get; set; }
        public int MesaId { get; set; }
        public int PlatoId { get; set; }
        public int Cantidad { get; set; }

        public PlatosPorPedido()
        {
        }
    }
}