using BusinessLogic.Transportes;
using Domain.Interfaces.Fabrica;
using Domain.Interfaces.Transporte;

namespace Infrastructure.Fabricas
{
    public class TransporteFabrica : ITransporteFabrica
    {
        public ITransporte CrearInstancia(string cTransporte)
        {
            ITransporte transporte = null;

            switch (cTransporte.ToUpper().Trim())
            {
                case "BARCO":
                    transporte = new TransporteBarco();
                    break;
                case "TREN":
                    transporte = new TransporteTren();
                    break;
                case "AVION":
                    transporte = new TransporteAvion();
                    break;
            }

            return transporte;
        }
    }
}
