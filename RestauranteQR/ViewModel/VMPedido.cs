using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteQR.ViewModel
{
    public class VMPedido
    {
        public List<VMPedidoItem> ListaVMPedidoItem { get; set; }
    }
    public class VMPedidoItem
    {
        public int IdPlato { get; set; }
        public string NombrePlato { get; set; }
        public int Cantidad { get; set; } = 0;

        public int PrecioPlato { get; set; }


    }
}
