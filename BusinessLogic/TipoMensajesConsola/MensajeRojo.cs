using Domain.Interfaces.TipoMensaje;
using System;

namespace BusinessLogic.TipoMensajes
{
    public class MensajeRojo : IMensaje
    {
        public void MostrarInformacion(string cMensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(cMensaje);
        }
    }
}

