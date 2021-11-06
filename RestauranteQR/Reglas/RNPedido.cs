using System;
using RestauranteQR.BaseDatos;

namespace RestauranteQR.Models
{
    public class RNPedido
    {

        public static void AgregarPedido(RestoDbContext _dbContext, Pedido pedido) 
        {
            _dbContext.Pedidos.Add(pedido);
        }
    }
}
