using Domain.Interfaces.TipoMensaje;
using System;

namespace BusinessLogic.TipoMensajes
{
    public class MensajeAmarillo : IMensaje
    {
        public void MostrarInformacion(string cMensaje)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(cMensaje);
        }
    }
}
