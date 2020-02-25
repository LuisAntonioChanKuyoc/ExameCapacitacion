using System;

namespace Domain.Entidades
{
    public class ResultadoPedidos
    {
        public string cOrigen { get; set; }
        public string cDestino { get; set; }
        public int iDistancia { get; set; }
        public string cPaqueteria { get; set; }
        public string cMedioTransporte { get; set; }
        public double fCostoEnvio { get; set; }
        public bool lPaqueteEntregado { get; set; }
        public string cTiempoEntrega { get; set; }
        public string cEviobarrato { get; set; }
        public string cError { get; set; }
        public DateTime dtFechaHoraPedido { get; set; }
    }
}
