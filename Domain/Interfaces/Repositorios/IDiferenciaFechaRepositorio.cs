using System;

namespace Domain.Interfaces.Repositorios
{
    public interface IDiferenciaFechaRepositorio
    {
        string obtenerDiferenciaFechas(DateTime _dtFechaEntrega);
    }
}
