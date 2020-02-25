using System.Collections.Generic;

namespace Domain.Entidades
{
    public class RequestPaqueteriaEstafeta
    {
        //public double dMargenUtilidad
        //{
        //    set => dMargenUtilidad = 20;
        //    get { return dMargenUtilidad; }
        //}

        //public Dictionary<int, string> lstTransporte
        //{
        //    set => lstTransporte = new Dictionary<int, string>()
        //        {
        //            { 1, "TREN" }
        //        };

        //    get { return lstTransporte; }
        //}

        public double dMargenUtilidad { get; set; } = 20;

        public Dictionary<int, string> lstTransporte { get; set; } = new Dictionary<int, string>()
                {
                     { 1, "TREN" },
                     { 2, "BARCO" }
                };

    }
}
