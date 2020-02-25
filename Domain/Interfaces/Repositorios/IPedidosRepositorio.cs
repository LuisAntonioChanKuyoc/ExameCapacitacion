using Domain.Entidades;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositorios
{
    public interface IPedidosRepositorio
    {
        List<Pedido> ObtenerPedidos();

        List<ResultadoPedidos> CrearListaNuevoObjetoDelPedido(List<Pedido> lstPedidos);
    }
}
