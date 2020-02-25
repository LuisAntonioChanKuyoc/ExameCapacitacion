using Domain.Interfaces.TipoMensaje;
using System;

namespace BusinessLogic.TipoMensajes
{
    public class MensajeVerde : IMensaje
    {
        public void MostrarInformacion(string cMensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(cMensaje);
        }
    }
}
