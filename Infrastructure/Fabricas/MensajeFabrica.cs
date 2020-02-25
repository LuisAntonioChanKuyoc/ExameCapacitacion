using BusinessLogic.TipoMensajes;
using Domain.Interfaces.Fabrica;
using Domain.Interfaces.TipoMensaje;

namespace Infrastructure.Fabricas
{
    public class MensajeFabrica : IMensajeFabrica
    {
        public IMensaje CrearInstancia(string cColor)
        {
            IMensaje mensaje;
            switch (cColor.ToUpper().Trim())
            {
                case "ROJO":
                    mensaje = new MensajeRojo();
                    break;
                case "VERDE":
                    mensaje = new MensajeVerde();
                    break;
                case "AMARILLO":
                    mensaje = new MensajeAmarillo();
                    break;
                default:
                    mensaje = new MensajeGris();
                    break;
            }

            return mensaje;
        }
    }
}
