using Domain.Interfaces.Fabrica;
using Domain.Interfaces.Paqueterias;
using Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositorios
{
    public class PaqueriaRepositorio : IPaqueriaRepositorio
    {
        private readonly IPaqueteriaFabrica paqueteriaFactory;
        public Dictionary<int, string> DicPaqueterias = new Dictionary<int, string>()
        {
            { 1, "DHL" },
            { 2, "ESTAFETA" },
            { 3, "FEDEX" }
        };

        public PaqueriaRepositorio(IPaqueteriaFabrica _paqueteria)
        {
            paqueteriaFactory = _paqueteria ?? throw new ArgumentNullException(nameof(_paqueteria));
        }

        public string ObtenerCostoEconomico(double _dDistancia, string _cTransporte, string _cPaqueteria, double dCostoAnterior)
        {
            foreach (var dic in DicPaqueterias)
            {
                if (dic.Value != _cPaqueteria.ToUpper().Trim())
                {
                    //se obtiene la paqueteria
                    IPaqueterias paqueteria = paqueteriaFactory.CrearInstancia(dic.Value);

                    //se manda a calcular el costo del pedido por el transporte, pero antes pasa por la paqueteria para saber si cuenta con ese transporte 
                    double dCosto = paqueteria.ObtenerCostoxPedido(_cTransporte, _dDistancia);

                    if (dCostoAnterior > dCosto)
                    {
                        return $"Si lo hubieses comprado en la paqueteria {dic.Value}, te hubiese salido {(dCostoAnterior - dCosto)} pesos menos.\n";
                    }
                }

            }

            //En caso de que no se encuentre algun precio mas barato se regresa un mensaje vacio
            return null;
        }
    }
}
