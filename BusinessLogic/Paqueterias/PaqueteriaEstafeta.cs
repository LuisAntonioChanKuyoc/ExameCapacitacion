using Domain.Entidades;
using Domain.Interfaces.Fabrica;
using Domain.Interfaces.Paqueterias;
using Domain.Interfaces.Transporte;
using System;

namespace BusinessLogic.Paqueterias
{
    public class PaqueteriaEstafeta : IPaqueterias
    {
        private ITransporte transporte = null;

        private readonly ITransporteFabrica transporteFabrica;

        readonly RequestPaqueteriaEstafeta RequestPaqueteria = new RequestPaqueteriaEstafeta();

        public PaqueteriaEstafeta(ITransporteFabrica _transporteFabrica)
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
                throw new Exception($"ESTAFETA no ofrece el servicio por {_cTransporte}, te recomendamos cotizar en otra empresa.");
            }

            transporte = transporteFabrica.CrearInstancia(_cTransporte);
        }
    }
}
