using Domain.Entidades;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositorios
{
    public interface IVisualizadorRepositorio
    {
        void PrintResultado(List<ResultadoPedidos> lstResultadoPedido);

        void PrintError(string _cMensaje);

    }
}
