using BusinessLogic.OpcionesFecha;
using Domain.Interfaces.Repositorios;
using System;

namespace Infrastructure.Repositorios
{
    public class DiferenciaFechaRepositorio : IDiferenciaFechaRepositorio
    {
        public Func<DateTime> Obtenerfecha { get; set; }


        public DiferenciaFechaRepositorio()
        {
            Obtenerfecha = () => DateTime.Now;

        }
            
        public string obtenerDiferenciaFechas(DateTime _dtFechaEntrega)
        {
            VerificarOpcionMeses meses = new VerificarOpcionMeses(_dtFechaEntrega, Obtenerfecha());
            var dias = new VerificarOpcionDias(_dtFechaEntrega, Obtenerfecha());
            var horas = new VerificarOpcionHoras(_dtFechaEntrega, Obtenerfecha());
            var minutos = new VerificarOpcionMinutos(_dtFechaEntrega, Obtenerfecha());

            meses.SetNext(dias).SetNext(horas).SetNext(minutos);

            string result = meses.ObtenerFechaHora();

            return result;
        }
    }
}
