using Domain.Interfaces.Handler;

namespace Handlers.Paquete
{
    public class AbstractDiferenciaFechaHandler : IDiferenciaFechaHandler
    {
        private IDiferenciaFechaHandler nextHandler;

        public virtual string ObtenerFechaHora()
        {
            if (nextHandler != null)
            {
                return nextHandler.ObtenerFechaHora();
            }
            else
            {
                return null;
            }
        }

        public IDiferenciaFechaHandler SetNext(IDiferenciaFechaHandler Handler)
        {
            nextHandler = Handler;

            return nextHandler;
        }
    }
}
