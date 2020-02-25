using Handlers.Paquete;
using System;

namespace BusinessLogic.OpcionesFecha
{
    public class VerificarOpcionHoras: AbstractDiferenciaFechaHandler
    {
        private TimeSpan DiferenciaHoras;

        public VerificarOpcionHoras(DateTime _dtFechaEntrega, DateTime _dtFechaActual)
        {
            //DiferenciaHoras = _dtFechaActual - _dtFechaEntrega;
            DiferenciaHoras = _dtFechaEntrega - _dtFechaActual;
        }

        public override string ObtenerFechaHora()
        {
            int iDiferenciaHoras = DiferenciaHoras.Hours;

            if (iDiferenciaHoras != 0)
            {
                return ObtenerMensajeDiferenciaHoras(iDiferenciaHoras);
            }
            else
            {
                return base.ObtenerFechaHora();

            }
        }

        private string ObtenerMensajeDiferenciaHoras(int _iDiferenciaHoras)
        {
            string cMensaje = _iDiferenciaHoras > 0 ? "+," : "-,";

            int iAbsoluteValor = Math.Abs(_iDiferenciaHoras);

            switch (iAbsoluteValor)
            {
                case 1: cMensaje += "1 hora"; break;
                default: cMensaje += iAbsoluteValor + " horas"; break;
            }

            return cMensaje;
        }
    }
}
