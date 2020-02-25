using Domain.Interfaces.TipoMensaje;
using System;

namespace BusinessLogic.TipoMensajes
{
    public class MensajeGris : IMensaje
    {
        public void MostrarInformacion(string cMensaje)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(cMensaje);
        }
    }
}

