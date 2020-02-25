using Domain.Interfaces.Fabrica;
using Domain.Interfaces.Repositorios;
using Infrastructure.Fabricas;
using Infrastructure.Repositorios;
using PedidosUI;
using System;

namespace Main
{
    public class Cliente
    {
        private static readonly string cRuta= @"..\..\..\DBPedidos.txt";
        public void Main()
        {
            IPedidosRepositorio pedidosRepositorio= ObtenerIPedidosRepositorio();
            IPaqueteriaFabrica paqueteriaFabrica = ObtenerIPaqueteriaFabrica();
            IDiferenciaFechaRepositorio diferenciaFechaRepositorio = ObtenerIDiferenciaFechaRepositorio();
            IPaqueriaRepositorio paqueriaRepositorio = ObtenerIPaqueriaRepositorio();
            IVisualizadorRepositorio visualizadorRepositorio = ObtenerIVisualizadorRepositorio();

            ReferenciaDelPedido visualizadorEventos = new ReferenciaDelPedido(pedidosRepositorio, paqueteriaFabrica, diferenciaFechaRepositorio, paqueriaRepositorio, visualizadorRepositorio);
            visualizadorEventos.VisualizarEventos();

            Console.ReadKey();
        }

        private static IPedidosRepositorio ObtenerIPedidosRepositorio()
        {
            return new PedidosRepositorio(cRuta, new LecturaAchivoRepositorio());
        }

        private static IPaqueteriaFabrica ObtenerIPaqueteriaFabrica()
        {
            return new PaqueteriaFabrica();
        }

        private static IDiferenciaFechaRepositorio ObtenerIDiferenciaFechaRepositorio()
        {
            return new DiferenciaFechaRepositorio();
        }

        private static IPaqueriaRepositorio ObtenerIPaqueriaRepositorio()
        {
            PaqueriaRepositorio paqueriaRepositorio = new PaqueriaRepositorio(new PaqueteriaFabrica());
            return paqueriaRepositorio;
        }

        private static IVisualizadorRepositorio ObtenerIVisualizadorRepositorio()
        {
            VisualizadorRepositorio visualizadorRepositorio = new VisualizadorRepositorio(new MensajeFabrica());

            return visualizadorRepositorio;
        }
    }
}
