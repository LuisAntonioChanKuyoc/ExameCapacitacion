using BusinessLogic.Paqueterias;
using Domain.Interfaces.Fabrica;
using Domain.Interfaces.Paqueterias;
using System;

namespace Infrastructure.Fabricas
{
    public class PaqueteriaFabrica : IPaqueteriaFabrica
    {
        public IPaqueterias CrearInstancia(string cPaqueteria)
        {
            IPaqueterias paqueteria;
            switch (cPaqueteria.ToUpper().Trim())
            {
                case "DHL": paqueteria = new PaqueteriaDHL(new TransporteFabrica()); break;
                case "ESTAFETA": paqueteria = new PaqueteriaEstafeta(new TransporteFabrica()); break;
                case "FEDEX": paqueteria = new PaqueteriaFedex(new TransporteFabrica()); break;
                default: throw new Exception($"La Paquetería: {cPaqueteria} no se encuentra registrada en nuestra red de distribución.");
            }

            return paqueteria;
        }
    }
}
