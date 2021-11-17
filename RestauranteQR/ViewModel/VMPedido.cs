using RestauranteQR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.ViewModel
{
    public class VMPedido
    {
        public int Id { get; set; }
        public int MesaId { get; set; }
        public List<PlatosPorPedido> ListaVMPedidoItem { get; set; }
    }
   
}
