using BusinessLogic.Paqueterias;
using Domain.Entidades;
using Domain.Interfaces.Fabrica;
using Domain.Interfaces.Paqueterias;
using Domain.Interfaces.Repositorios;
using Infrastructure.Fabricas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PedidosUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosU.Tests
{
    [TestClass()]
    public class ReferenciaDelPedidoTests
    {
        [TestMethod()]
        public void ReferenciaDelPedidoTest_Instancia_Correcta()
        {

            Mock<IPedidosRepositorio> DOCpedidosRepositorio = new Mock<IPedidosRepositorio>();
            Mock<IPaqueteriaFabrica> DOCpaqueteriaFabrica = new Mock<IPaqueteriaFabrica>();
            Mock<IDiferenciaFechaRepositorio> DOCdiferenciaFechaRepositorio = new Mock<IDiferenciaFechaRepositorio>();
            Mock<IPaqueriaRepositorio> DOCpaqueriaRepositorio = new Mock<IPaqueriaRepositorio>();
            Mock<IVisualizadorRepositorio> DOCvisualizadorRepositorio = new Mock<IVisualizadorRepositorio>();

            ReferenciaDelPedido referenciaDelPedido = new ReferenciaDelPedido(DOCpedidosRepositorio.Object, DOCpaqueteriaFabrica.Object, DOCdiferenciaFechaRepositorio.Object, DOCpaqueriaRepositorio.Object, DOCvisualizadorRepositorio.Object);

            Assert.IsInstanceOfType(referenciaDelPedido, typeof(ReferenciaDelPedido));
        }

        [TestMethod]
        public void VisualizarEventos_IPedidosRepositorioNulo_Excepcion()
        {
            Mock<IPaqueteriaFabrica> DOCpaqueteriaFabrica = new Mock<IPaqueteriaFabrica>();
            Mock<IDiferenciaFechaRepositorio> DOCdiferenciaFechaRepositorio = new Mock<IDiferenciaFechaRepositorio>();
            Mock<IPaqueriaRepositorio> DOCpaqueriaRepositorio = new Mock<IPaqueriaRepositorio>();
            Mock<IVisualizadorRepositorio> DOCvisualizadorRepositorio = new Mock<IVisualizadorRepositorio>();


            Assert.ThrowsException<ArgumentNullException>(() =>
           new ReferenciaDelPedido(null, DOCpaqueteriaFabrica.Object, DOCdiferenciaFechaRepositorio.Object, DOCpaqueriaRepositorio.Object, DOCvisualizadorRepositorio.Object));

        }

        [TestMethod]
        public void VisualizarEventos_IPaqueteriaFabricaNulo_Excepcion()
        {
            Mock<IPedidosRepositorio> DOCpedidosRepositorio = new Mock<IPedidosRepositorio>();
            Mock<IDiferenciaFechaRepositorio> DOCdiferenciaFechaRepositorio = new Mock<IDiferenciaFechaRepositorio>();
            Mock<IPaqueriaRepositorio> DOCpaqueriaRepositorio = new Mock<IPaqueriaRepositorio>();
            Mock<IVisualizadorRepositorio> DOCvisualizadorRepositorio = new Mock<IVisualizadorRepositorio>();


            Assert.ThrowsException<ArgumentNullException>(() =>
           new ReferenciaDelPedido(DOCpedidosRepositorio.Object, null, DOCdiferenciaFechaRepositorio.Object, DOCpaqueriaRepositorio.Object, DOCvisualizadorRepositorio.Object));

        }

        [TestMethod]
        public void VisualizarEventos_IDiferenciaFechaRepositorioNulo_Excepcion()
        {
            Mock<IPedidosRepositorio> DOCpedidosRepositorio = new Mock<IPedidosRepositorio>();
            Mock<IPaqueteriaFabrica> DOCpaqueteriaFabrica = new Mock<IPaqueteriaFabrica>();
            Mock<IPaqueriaRepositorio> DOCpaqueriaRepositorio = new Mock<IPaqueriaRepositorio>();
            Mock<IVisualizadorRepositorio> DOCvisualizadorRepositorio = new Mock<IVisualizadorRepositorio>();


            Assert.ThrowsException<ArgumentNullException>(() =>
           new ReferenciaDelPedido(DOCpedidosRepositorio.Object, DOCpaqueteriaFabrica.Object, null, DOCpaqueriaRepositorio.Object, DOCvisualizadorRepositorio.Object));

        }

        [TestMethod]
        public void VisualizarEventos_IPaqueriaRepositorioNulo_Excepcion()
        {
            Mock<IPedidosRepositorio> DOCpedidosRepositorio = new Mock<IPedidosRepositorio>();
            Mock<IPaqueteriaFabrica> DOCpaqueteriaFabrica = new Mock<IPaqueteriaFabrica>();
            Mock<IDiferenciaFechaRepositorio> DOCdiferenciaFechaRepositorio = new Mock<IDiferenciaFechaRepositorio>();
            Mock<IVisualizadorRepositorio> DOCvisualizadorRepositorio = new Mock<IVisualizadorRepositorio>();


            Assert.ThrowsException<ArgumentNullException>(() =>
           new ReferenciaDelPedido(DOCpedidosRepositorio.Object, DOCpaqueteriaFabrica.Object, DOCdiferenciaFechaRepositorio.Object, null, DOCvisualizadorRepositorio.Object));

        }

        [TestMethod]
        public void VisualizarEventos_IVisualizadorRepositorioNulo_Excepcion()
        {
            Mock<IPedidosRepositorio> DOCpedidosRepositorio = new Mock<IPedidosRepositorio>();
            Mock<IPaqueteriaFabrica> DOCpaqueteriaFabrica = new Mock<IPaqueteriaFabrica>();
            Mock<IDiferenciaFechaRepositorio> DOCdiferenciaFechaRepositorio = new Mock<IDiferenciaFechaRepositorio>();
            Mock<IPaqueriaRepositorio> DOCpaqueriaRepositorio = new Mock<IPaqueriaRepositorio>();


            Assert.ThrowsException<ArgumentNullException>(() =>
           new ReferenciaDelPedido(DOCpedidosRepositorio.Object, DOCpaqueteriaFabrica.Object, DOCdiferenciaFechaRepositorio.Object, DOCpaqueriaRepositorio.Object, null));

        }

        [TestMethod()]
        public void VisualizarEventosTest()
        {
            Mock<IPedidosRepositorio> DOCpedidosRepositorio = new Mock<IPedidosRepositorio>();
            Mock<IPaqueteriaFabrica> DOCpaqueteriaFabrica = new Mock<IPaqueteriaFabrica>();
            Mock<IDiferenciaFechaRepositorio> DOCdiferenciaFechaRepositorio = new Mock<IDiferenciaFechaRepositorio>();
            Mock<IPaqueriaRepositorio> DOCpaqueriaRepositorio = new Mock<IPaqueriaRepositorio>();
            Mock<IVisualizadorRepositorio> DOCvisualizadorRepositorio = new Mock<IVisualizadorRepositorio>();

            ReferenciaDelPedido referenciaDelPedido = new ReferenciaDelPedido(DOCpedidosRepositorio.Object, DOCpaqueteriaFabrica.Object, DOCdiferenciaFechaRepositorio.Object, DOCpaqueriaRepositorio.Object, DOCvisualizadorRepositorio.Object);

            referenciaDelPedido.VisualizarEventos();

            DOCpedidosRepositorio.Verify(x => x.ObtenerPedidos(), Times.Once);
        }

        [TestMethod()]
        public void RecorrerListaPedidos_VerificarProceso_Correctamente()
        {
            Mock<IPedidosRepositorio> DOCpedidosRepositorio = new Mock<IPedidosRepositorio>();
            Mock<IPaqueteriaFabrica> DOCpaqueteriaFabrica = new Mock<IPaqueteriaFabrica>();
            Mock<IDiferenciaFechaRepositorio> DOCdiferenciaFechaRepositorio = new Mock<IDiferenciaFechaRepositorio>();
            Mock<IPaqueriaRepositorio> DOCpaqueriaRepositorio = new Mock<IPaqueriaRepositorio>();
            Mock<IVisualizadorRepositorio> DOCvisualizadorRepositorio = new Mock<IVisualizadorRepositorio>();


            List<ResultadoPedidos> resultadoPedidos = new List<ResultadoPedidos>()
            {
                new ResultadoPedidos{cDestino="China",cOrigen="Cancún",cMedioTransporte="Avión",cPaqueteria="DHL",dtFechaHoraPedido=DateTime.Now,iDistancia=446400,lPaqueteEntregado=true},
                new ResultadoPedidos{cDestino="Mérida",cOrigen="Cozumel",cMedioTransporte="Avión",cPaqueteria="DHL",dtFechaHoraPedido=DateTime.Now,iDistancia=446400, lPaqueteEntregado=true},
                new ResultadoPedidos{cDestino="China",cOrigen="Cancún",cMedioTransporte="Avión",cPaqueteria="DHL",dtFechaHoraPedido=DateTime.Now,iDistancia=446400, lPaqueteEntregado=true},
                new ResultadoPedidos{cDestino="China",cOrigen="Cancún",cMedioTransporte="Avión",cPaqueteria="DHL",dtFechaHoraPedido=DateTime.Now,iDistancia=446400, lPaqueteEntregado=true},
            };

            DOCpedidosRepositorio.Setup(x => x.CrearListaNuevoObjetoDelPedido(It.IsAny<List<Pedido>>())).Returns(resultadoPedidos);

            DOCpaqueteriaFabrica.Setup(x => x.CrearInstancia(It.IsAny<string>())).Returns(new PaqueteriaDHL(new TransporteFabrica()));
            DOCdiferenciaFechaRepositorio.Setup(x => x.obtenerDiferenciaFechas(It.IsAny<DateTime>())).Returns("DHL,-");




            ReferenciaDelPedido referenciaDelPedido = new ReferenciaDelPedido(DOCpedidosRepositorio.Object, DOCpaqueteriaFabrica.Object, DOCdiferenciaFechaRepositorio.Object, DOCpaqueriaRepositorio.Object, DOCvisualizadorRepositorio.Object);

            List<Pedido> lstPedidos = new List<Pedido>()
            {
                new Pedido{cDestino="China",cOrigen="Cancún",cMedioTransporte="Avión",cPaqueteria="DHL",dtFechaHoraPedido=DateTime.Now,iDistancia=446400},
                new Pedido{cDestino="Mérida",cOrigen="Cozumel",cMedioTransporte="Avión",cPaqueteria="DHL",dtFechaHoraPedido=DateTime.Now,iDistancia=446400},
                new Pedido{cDestino="China",cOrigen="Cancún",cMedioTransporte="Avión",cPaqueteria="DHL",dtFechaHoraPedido=DateTime.Now,iDistancia=446400},
                new Pedido{cDestino="China",cOrigen="Cancún",cMedioTransporte="Avión",cPaqueteria="DHL",dtFechaHoraPedido=DateTime.Now,iDistancia=446400},
            };

            referenciaDelPedido.RecorrerListaPedidos(lstPedidos);

            DOCpaqueteriaFabrica.Verify(x => x.CrearInstancia(It.IsAny<string>()));
            //DOCdiferenciaFechaRepositorio.Verify(x => x.obtenerDiferenciaFechas(It.IsAny<DateTime>()));


        }

        [TestMethod()]
        public void ObtenerCostoxPedido_Verificar_Respuesta()
        {
            Mock<IPedidosRepositorio> DOCpedidosRepositorio = new Mock<IPedidosRepositorio>();
            Mock<IPaqueteriaFabrica> DOCpaqueteriaFabrica = new Mock<IPaqueteriaFabrica>();
            Mock<IDiferenciaFechaRepositorio> DOCdiferenciaFechaRepositorio = new Mock<IDiferenciaFechaRepositorio>();
            Mock<IPaqueriaRepositorio> DOCpaqueriaRepositorio = new Mock<IPaqueriaRepositorio>();
            Mock<IVisualizadorRepositorio> DOCvisualizadorRepositorio = new Mock<IVisualizadorRepositorio>();

            Mock<IPaqueterias> paqueteria = new Mock<IPaqueterias>();
            paqueteria.Setup(x => x.ObtenerCostoxPedido(It.IsAny<string>(), It.IsAny<double>())).Returns(2.21);

            DOCpaqueteriaFabrica.Setup(x => x.CrearInstancia(It.IsAny<string>())).Returns(paqueteria.Object);


            ReferenciaDelPedido referenciaDelPedido = new ReferenciaDelPedido(DOCpedidosRepositorio.Object, DOCpaqueteriaFabrica.Object, DOCdiferenciaFechaRepositorio.Object, DOCpaqueriaRepositorio.Object, DOCvisualizadorRepositorio.Object);

            var oPedido = new ResultadoPedidos { cDestino = "China", cOrigen = "Cancún", cMedioTransporte = "Avión", cPaqueteria = "DHL", dtFechaHoraPedido = DateTime.Now, iDistancia = 446400 };
            var result = referenciaDelPedido.ObtenerCostoxPedido(paqueteria.Object, oPedido);

            Assert.AreEqual(result, 2.21);

        }

        [TestMethod()]
        public void ObtenerTiempoEntrega_Verificar_Respuesta()
        {
            Mock<IPedidosRepositorio> DOCpedidosRepositorio = new Mock<IPedidosRepositorio>();
            Mock<IPaqueteriaFabrica> DOCpaqueteriaFabrica = new Mock<IPaqueteriaFabrica>();
            Mock<IDiferenciaFechaRepositorio> DOCdiferenciaFechaRepositorio = new Mock<IDiferenciaFechaRepositorio>();
            Mock<IPaqueriaRepositorio> DOCpaqueriaRepositorio = new Mock<IPaqueriaRepositorio>();
            Mock<IVisualizadorRepositorio> DOCvisualizadorRepositorio = new Mock<IVisualizadorRepositorio>();

            Mock<IPaqueterias> paqueteria = new Mock<IPaqueterias>();
            paqueteria.Setup(x => x.ObtenerTiempoEntrega(It.IsAny<double>())).Returns(2.21);

            DOCpaqueteriaFabrica.Setup(x => x.CrearInstancia(It.IsAny<string>())).Returns(paqueteria.Object);


            ReferenciaDelPedido referenciaDelPedido = new ReferenciaDelPedido(DOCpedidosRepositorio.Object, DOCpaqueteriaFabrica.Object, DOCdiferenciaFechaRepositorio.Object, DOCpaqueriaRepositorio.Object, DOCvisualizadorRepositorio.Object);

            var oPedido = new ResultadoPedidos { cDestino = "China", cOrigen = "Cancún", cMedioTransporte = "Avión", cPaqueteria = "DHL", dtFechaHoraPedido = DateTime.Now, iDistancia = 446400 };
            var result = referenciaDelPedido.ObtenerCostoxPedido(paqueteria.Object, oPedido);

            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void ObtenerDiferenciaFechas_Verificar_Resultado()
        {

            Mock<IPedidosRepositorio> DOCpedidosRepositorio = new Mock<IPedidosRepositorio>();
            Mock<IPaqueteriaFabrica> DOCpaqueteriaFabrica = new Mock<IPaqueteriaFabrica>();
            Mock<IDiferenciaFechaRepositorio> DOCdiferenciaFechaRepositorio = new Mock<IDiferenciaFechaRepositorio>();
            Mock<IPaqueriaRepositorio> DOCpaqueriaRepositorio = new Mock<IPaqueriaRepositorio>();
            Mock<IVisualizadorRepositorio> DOCvisualizadorRepositorio = new Mock<IVisualizadorRepositorio>();

            DOCdiferenciaFechaRepositorio.Setup(x=>x.obtenerDiferenciaFechas(It.IsAny<DateTime>())).Returns("Valor");

            ReferenciaDelPedido referenciaDelPedido = new ReferenciaDelPedido(DOCpedidosRepositorio.Object, DOCpaqueteriaFabrica.Object, DOCdiferenciaFechaRepositorio.Object, DOCpaqueriaRepositorio.Object, DOCvisualizadorRepositorio.Object);

            var oPedido = new ResultadoPedidos { cDestino = "China", cOrigen = "Cancún", cMedioTransporte = "Avión", cPaqueteria = "DHL", dtFechaHoraPedido = DateTime.Now, iDistancia = 446400 };

            var result=referenciaDelPedido.ObtenerDiferenciaFechas(oPedido);

            Assert.AreEqual("Valor", result);

        }
    }
}