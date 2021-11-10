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
