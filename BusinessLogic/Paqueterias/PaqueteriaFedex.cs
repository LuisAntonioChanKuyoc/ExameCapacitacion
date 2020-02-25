using Domain.Entidades;
using Domain.Interfaces.Fabrica;
using Domain.Interfaces.Paqueterias;
using Domain.Interfaces.Transporte;
using System;

namespace BusinessLogic.Paqueterias
{
    public class PaqueteriaFedex : IPaqueterias
    {
        private readonly ITransporteFabrica transporteFabrica;

        private ITransporte transporte = null;
        RequestPaqueteriaFedex RequestPaqueteria = new RequestPaqueteriaFedex();

        public PaqueteriaFedex(ITransporteFabrica _transporteFabrica)
        {
            transporteFabrica = _transporteFabrica ?? throw new ArgumentNullException(nameof(_transporteFabrica));
        }

        public double ObtenerCostoxPedido(string cTransporte, double fDistancia)
        {
            ValidarTransporte(cTransporte);

            double dCosto = transporte.ObtenerCostoEnvio(RequestPaqueteria.dMargenUtilidad, fDistancia);

            return dCosto;
        }

        public double ObtenerTiempoEntrega(double dDistancia)
        {
            double dHoras = transporte.ObtenerTiempoEntrega(dDistancia);

            return dHoras;
        }

        private void ValidarTransporte(string _cTransporte)
        {
            bool existe = RequestPaqueteria.lstTransporte.ContainsValue(_cTransporte.ToUpper().Trim());

            if (!existe)
            {
                throw new Exception($"FEDEX no ofrece el servicio por {_cTransporte}, te recomendamos cotizar en otra empresa.");
            }

            transporte = transporteFabrica.CrearInstancia(_cTransporte);
        }
    }
}
