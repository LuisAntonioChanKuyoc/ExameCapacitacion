using Domain.Entidades;
using Domain.Interfaces.Fabrica;
using Domain.Interfaces.Paqueterias;
using Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;

namespace PedidosUI
{
    public class ReferenciaDelPedido
    {
        private readonly IPedidosRepositorio pedidosRepositorio;
        private readonly IPaqueteriaFabrica paqueteriaFabrica;
        private readonly IDiferenciaFechaRepositorio diferenciaFechaRepositorio;
        private readonly IPaqueriaRepositorio paqueriaRepositorio;
        private readonly IVisualizadorRepositorio visualizadorRepositorio;

        public ReferenciaDelPedido(IPedidosRepositorio _pedidosRepositorio, IPaqueteriaFabrica _paqueteriaFabrica, IDiferenciaFechaRepositorio _diferenciaFechaRepositorio, IPaqueriaRepositorio _paqueriaRepositorio, IVisualizadorRepositorio _visualizadorRepositorio)
        {
            pedidosRepositorio = _pedidosRepositorio ?? throw new ArgumentNullException(nameof(_pedidosRepositorio));
            paqueteriaFabrica = _paqueteriaFabrica ?? throw new ArgumentNullException(nameof(_paqueteriaFabrica));
            diferenciaFechaRepositorio = _diferenciaFechaRepositorio ?? throw new ArgumentNullException(nameof(_diferenciaFechaRepositorio));
            paqueriaRepositorio = _paqueriaRepositorio ?? throw new ArgumentNullException(nameof(_paqueriaRepositorio));
            visualizadorRepositorio = _visualizadorRepositorio ?? throw new ArgumentNullException(nameof(_visualizadorRepositorio));
        }

        public void VisualizarEventos()
        {
            List<Pedido> lstPedidos = pedidosRepositorio.ObtenerPedidos();
            RecorrerListaPedidos(lstPedidos);
        }

        public void RecorrerListaPedidos(List<Pedido> lstPedidos)
        {
            List<ResultadoPedidos> lstResultPedidos = CrearListaNuevoObjetoDelPedido(lstPedidos);

            try
            {
                foreach (var oPedido in lstResultPedidos)
                {
                    try
                    {
                        IPaqueterias paqueteria = paqueteriaFabrica.CrearInstancia(oPedido.cPaqueteria);

                        oPedido.fCostoEnvio = ObtenerCostoxPedido(paqueteria, oPedido);

                        double HorasParaEntregarPedidoxTransporte = ObtenerTiempoEntrega(paqueteria,oPedido);
                        oPedido.dtFechaHoraPedido.AddHours(HorasParaEntregarPedidoxTransporte);

                        string TiempoRestanteEntregaTemp = ObtenerDiferenciaFechas(oPedido);

                        oPedido.lPaqueteEntregado = (TiempoRestanteEntregaTemp.Split(',')[0] == "-") ? true : false;

                        oPedido.cTiempoEntrega = TiempoRestanteEntregaTemp.Split(',')[1];

                        //oPedido.cEviobarrato = paqueriaRepositorio.ObtenerCostoEconomico(oPedido.iDistancia, oPedido.cMedioTransporte, oPedido.cPaqueteria, oPedido.fCostoEnvio);

                    }
                    catch (Exception e)
                    {
                        oPedido.cError = e.Message;
                    }
                }

                visualizadorRepositorio.PrintResultado(lstResultPedidos);
            }
            catch (Exception e)
            {
                visualizadorRepositorio.PrintError(e.Message);
            }
        }

        public double ObtenerCostoxPedido(IPaqueterias paqueteria, ResultadoPedidos oPedido)
        {
            return paqueteria.ObtenerCostoxPedido(oPedido.cMedioTransporte, oPedido.iDistancia);
        }

        public double ObtenerTiempoEntrega(IPaqueterias paqueteria, ResultadoPedidos oPedido)
        {
            return paqueteria.ObtenerTiempoEntrega(oPedido.iDistancia);
        }

        public string ObtenerDiferenciaFechas(ResultadoPedidos oPedido)
        {
            return diferenciaFechaRepositorio.obtenerDiferenciaFechas(oPedido.dtFechaHoraPedido);
        }

        public List<ResultadoPedidos> CrearListaNuevoObjetoDelPedido(List<Pedido> lstPedidos)
        {
            return pedidosRepositorio.CrearListaNuevoObjetoDelPedido(lstPedidos);
        }
    }
}
