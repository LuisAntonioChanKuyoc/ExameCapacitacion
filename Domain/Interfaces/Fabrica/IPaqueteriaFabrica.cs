using Domain.Interfaces.Paqueterias;

namespace Domain.Interfaces.Fabrica
{
    public interface IPaqueteriaFabrica
    {
        IPaqueterias CrearInstancia(string cPaqueteria);
    }
}
