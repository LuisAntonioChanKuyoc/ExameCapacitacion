namespace Domain.Interfaces.Handler
{
    public interface IDiferenciaFechaHandler
    {
        IDiferenciaFechaHandler SetNext(IDiferenciaFechaHandler Handler);

        string ObtenerFechaHora();
    }
}
