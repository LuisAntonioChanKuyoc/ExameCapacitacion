using System.Collections.Generic;

namespace Domain.Entidades
{
    public class RequestPaqueteriaFedex
    {
        //public double dMargenUtilidad
        //{
        //    set => dMargenUtilidad = 50;
        //    get { return dMargenUtilidad; }
        //}

        //public Dictionary<int, string> lstTransporte
        //{
        //    set => lstTransporte = new Dictionary<int, string>()
        //        {
        //              { 1, "BARCO"}
        //        };

        //    get { return lstTransporte; }
        //}

        public double dMargenUtilidad { get; set; } = 50;

        public Dictionary<int, string> lstTransporte { get; set; } = new Dictionary<int, string>()
                {
                     { 1, "BARCO" }
                };
    }
}
