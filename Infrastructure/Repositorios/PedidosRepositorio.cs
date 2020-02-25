using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositorios
{
    public class PedidosRepositorio : IPedidosRepositorio
    {
        private readonly string cRuta;
        private readonly ILecturaAchivoRepositorio lecturaAchivoRepositorio;

        public PedidosRepositorio(string _cRuta, ILecturaAchivoRepositorio _lecturaAchivoRepositorio)
        {
            if (string.IsNullOrEmpty(_cRuta))
            {
                throw new ArgumentNullException(nameof(_cRuta));
            }

            cRuta = _cRuta;
            lecturaAchivoRepositorio = _lecturaAchivoRepositorio ?? throw new ArgumentNullException(nameof(_lecturaAchivoRepositorio));
        }

        public List<Pedido> ObtenerPedidos()
        {
            List<string> lstPedidos = ObtenerPedidosDelArchivo();

            List<Pedido> lstPedidosEntidad = (from pedidos in lstPedidos
                                              select new Pedido
                                              {
                                                  cOrigen = pedidos.Split(',')[0],
                                                  cDestino = pedidos.Split(',')[1],
                                                  iDistancia = int.Parse(pedidos.Split(',')[2]),
                                                  cPaqueteria = pedidos.Split(',')[3],
                                                  cMedioTransporte = pedidos.Split(',')[4],
                                                  dtFechaHoraPedido = Convert.ToDateTime(pedidos.Split(',')[5])
                                              }).ToList();

            return lstPedidosEntidad;
        }

        public List<ResultadoPedidos> CrearListaNuevoObjetoDelPedido(List<Pedido> lstPedidos)
        {
            var lstResultadoPedido = (from oPedido in lstPedidos
                                      select new ResultadoPedidos
                                      {
                                          cDestino = oPedido.cDestino,
                                          cMedioTransporte = oPedido.cMedioTransporte,
                                          cOrigen = oPedido.cOrigen,
                                          cPaqueteria = oPedido.cPaqueteria,
                                          cTiempoEntrega = oPedido.cMedioTransporte,
                                          dtFechaHoraPedido = oPedido.dtFechaHoraPedido,
                                          iDistancia = oPedido.iDistancia
                                      }
                                     ).ToList();

            return lstResultadoPedido;
        }

        private List<string> ObtenerPedidosDelArchivo()
        {
            return lecturaAchivoRepositorio.LeerAchivo(cRuta);
        }
    }
}
