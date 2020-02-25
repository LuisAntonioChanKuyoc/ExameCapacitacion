using Domain.Entidades;
using Domain.Interfaces.Fabrica;
using Domain.Interfaces.Repositorios;
using Domain.Interfaces.TipoMensaje;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositorios
{
    public class VisualizadorRepositorio : IVisualizadorRepositorio
    {
        private readonly IMensajeFabrica mensajeFabrica;

        public VisualizadorRepositorio(IMensajeFabrica mensajeFabrica)
        {
            this.mensajeFabrica = mensajeFabrica ?? throw new ArgumentNullException(nameof(mensajeFabrica));
        }

        public void PrintError(string _cMensaje)
        {
            IMensaje MensajeConsola = mensajeFabrica.CrearInstancia("ROJO");
            MensajeConsola.MostrarInformacion(_cMensaje);
        }

        public void PrintResultado(List<ResultadoPedidos> lstResultadoPedido)
        {
            foreach (var lstPedidos in lstResultadoPedido)
            {
                if (ValidarMensajeVacio(lstPedidos.cError))
                {
                    if (lstPedidos.lPaqueteEntregado)
                    {
                        ImprimirMsgPaqueteEntregado(lstPedidos.cOrigen, lstPedidos.cDestino, lstPedidos.cTiempoEntrega, lstPedidos.fCostoEnvio, lstPedidos.cPaqueteria);
                    }
                    else
                    {
                        ImprimirMsgPaqueteEnCamino(lstPedidos.cOrigen, lstPedidos.cDestino, lstPedidos.cTiempoEntrega, lstPedidos.fCostoEnvio, lstPedidos.cPaqueteria);
                    }

                    IMensaje MensajeConsola = mensajeFabrica.CrearInstancia("");
                    MensajeConsola.MostrarInformacion(lstPedidos.cEviobarrato);

                }
                else
                {
                    IMensaje MensajeConsola = mensajeFabrica.CrearInstancia("ROJO");
                    MensajeConsola.MostrarInformacion(lstPedidos.cError + "\n");
                }
            }
        }

        private void ImprimirMsgPaqueteEntregado(string _cOrigen, string _cDestino, string _cTiempoEntrega, double _cCostoEnvio, string _cPaqueteria)
        {
            string cMensajeEntregado = $"Tu paquete salio de {_cOrigen} y llegó a {_cDestino} hace {_cTiempoEntrega}, tuvo un costo de ${_cCostoEnvio} pesos. Cualquier Reclamación con {_cPaqueteria}.";
            IMensaje MensajeConsola = mensajeFabrica.CrearInstancia("VERDE");
            MensajeConsola.MostrarInformacion(cMensajeEntregado);

        }

        private void ImprimirMsgPaqueteEnCamino(string _cOrigen, string _cDestino, string _cTiempoEntrega, double _cCostoEnvio, string _cPaqueteria)
        {
            string cMensajeNoEntregado = $"Tu paquete ha salido de {_cOrigen} y llegará a {_cDestino} dentro de {_cTiempoEntrega}, tendra un costo de ${_cCostoEnvio} pesos. Cualquier Reclamación con {_cPaqueteria}.";
            IMensaje MensajeConsola = mensajeFabrica.CrearInstancia("AMARILLO");
            MensajeConsola.MostrarInformacion(cMensajeNoEntregado);
        }

        private bool ValidarMensajeVacio(string cMensaje)
        {
            if (cMensaje != null && cMensaje != "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
