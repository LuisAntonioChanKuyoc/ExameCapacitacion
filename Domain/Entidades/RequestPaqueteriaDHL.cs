using System.Collections.Generic;

namespace Domain.Entidades
{
    public class RequestPaqueteriaDHL
    {
        //public double dMargenUtilidad
        //{
        //    set => dMargenUtilidad = 40;
        //    get { return dMargenUtilidad; }
        //}
        public double dMargenUtilidad { get; set; } = 40;
        
        //public Dictionary<int, string> lstTransporte
        //{
        //    set => lstTransporte = new Dictionary<int, string>()
        //        {
        //             { 1, "AVION" },
        //             { 2, "BARCO" }
        //        };

            //    get { return lstTransporte; }
            //}

        public Dictionary<int, string> lstTransporte { get; set; }= new Dictionary<int, string>()
                {
                     { 1, "AVION" },
                     { 2, "BARCO" }
                };
    }
}
