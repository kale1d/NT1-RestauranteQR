    using System;
    using System.Collections.Generic;
using System.Linq;
using RestauranteQR.BaseDatos;
    using RestauranteQR.ViewModel;

namespace RestauranteQR.Models
{
    public class RNPedido
    {

        public static void AgregarPedido(RestoDbContext _dbContext, VMPedido pedido)   
        {
            _dbContext.Database.BeginTransaction();
            var pedido2 = new Pedido();
            // pedido2.Id = pedido.Id;
            pedido2.MesaId = pedido.MesaId;
            _dbContext.Add(pedido2);
            _dbContext.SaveChanges();
            pedido.Id = pedido2.Id;

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
            var ingrediDePlatos = _dbContext.IngredientePlato;
           
            foreach (var p in platosPedidos)
            {

                foreach (var plato in platos)
                {
                    if (p.PlatoId == plato.Id)
                    {
                        
                        var ingreDelPla = new List<int>();
                        foreach (var ingPla in ingrediDePlatos.ToList())
                        {
                            if(ingPla.PlatoId == plato.Id)
                            {
                                ingreDelPla.Add(ingPla.IngredienteId);
                            }
                        }
                       foreach(var ing in ingreDelPla)
                        {
                            Ingrediente ingActual = _dbContext.Ingredientes.Single(x => x.Id == Convert.ToInt32(ing));

                            if (pedido2.Id == p.PedidoId)
                            {
                                var cant = ingActual.Cantidad -= p.Cantidad;
                                if (cant >= 0)
                                {
                                    _dbContext.Ingredientes.Update(ingActual);
                                    p.NombrePlato = plato.Nombre;
                                    p.PrecioPlato = plato.Precio;
                                    _dbContext.PlatosPorPedido.Update(p);
                                }
                                else
                                {
                                    throw new Exception(plato.Nombre);
                                }
                            }

                        }
                    }
                }
            }
            _dbContext.SaveChanges();

            _dbContext.Database.CommitTransaction();
        }
    }
        
    }
