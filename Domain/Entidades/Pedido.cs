using System;

namespace Domain.Entidades
{
    public class Pedido
    {
        public string cOrigen { get; set; }
        public string cDestino {get;set;}
        public int iDistancia { get; set; }
        public string cPaqueteria { get; set; }
        public string cMedioTransporte { get; set; }
        public DateTime dtFechaHoraPedido { get; set; }
    }
}
