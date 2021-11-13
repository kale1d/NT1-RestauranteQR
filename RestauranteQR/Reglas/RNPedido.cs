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

                foreach (var platoPorPedido in pedido.ListaVMPedidoItem)
                {
                platoPorPedido.PedidoId = pedido2.Id;
                platoPorPedido.MesaId = pedido2.MesaId;
                    if (platoPorPedido.Cantidad > 0) {
                    _dbContext.PlatosPorPedido.Add(platoPorPedido);
                    }

                }
                    _dbContext.SaveChanges();

                var platosPedidos = _dbContext.PlatosPorPedido;
                var platos = _dbContext.Platos;
                var ingredientes = _dbContext.Ingredientes;


                foreach (var p in platosPedidos)
                {
                
                    foreach (var plato in platos)
                    {
                        if (p.PlatoId == plato.Id)
                        {
                            foreach (var ing in ingredientes)
                            {
                                if (plato.IngredienteId1 == ing.Id || plato.IngredienteId2 == ing.Id)
                                {
                                 if(pedido2.Id == p.PedidoId)
                                 {
                                    ing.Cantidad -= p.Cantidad;
                                    _dbContext.Ingredientes.Update(ing);
                                   }
                                 }
                            }
                        }
                    }
                }
                _dbContext.SaveChanges();
           

            }
        }
    }
