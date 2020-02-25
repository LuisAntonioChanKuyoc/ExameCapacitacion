using Domain.Interfaces.Transporte;

namespace Domain.Interfaces.Fabrica
{
    public interface ITransporteFabrica
    {
        ITransporte CrearInstancia(string cTransporte);
    }
}
