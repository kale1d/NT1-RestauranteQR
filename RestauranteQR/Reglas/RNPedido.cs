using System;
using System.Collections.Generic;
using RestauranteQR.BaseDatos;
using RestauranteQR.ViewModel;

namespace RestauranteQR.Models
{
    public class RNPedido
    {

        public static void AgregarPedido(RestoDbContext _dbContext, VMPedido pedido)   /*List<PlatosPorPedido> platosPorPedido*/
        {
            var pedido2 = new Pedido();
            pedido2.Id = pedido.Id;
            pedido2.MesaId = pedido.MesaId;
            _dbContext.Add(pedido2);
            _dbContext.SaveChanges();

            foreach (var plato in pedido.ListaVMPedidoItem.ToArray())
            {
                Console.Write(plato);
                plato.PedidoId = pedido2.Id;
                plato.MesaId = pedido2.MesaId;
                _dbContext.PlatosPorPedido.Add(plato);
            }

            _dbContext.SaveChanges();
            //foreach (Plato p in pedido.Platos)
            //{
            //    PlatosPorPedido pxp = new PlatoPorPedido();
            //    pxp.PlatoId = p.Id;
            //    pxp.NombrePlato = p.Nombre;
            //    pxp.PrecioPlato = p.Precio;
            //    pxp.Cantidad = 10;

            //    _dbContext.PlatosPorPedido.Add(pxp);
            //}
            //_dbContext.Pedidos.Add(pedido);
            //_dbContext.PlatosPorPedido.Add(platosPorPedido);
            //for ()
            //{
            //    _dbContext.PlatosPorPedido.Add(platosPorPedido);
            //}

        }
    }
}
