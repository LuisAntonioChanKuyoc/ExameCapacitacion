using Domain.Interfaces.TipoMensaje;

namespace Domain.Interfaces.Fabrica
{
    public interface IMensajeFabrica
    {
        IMensaje CrearInstancia(string cColor); 
    }
}
