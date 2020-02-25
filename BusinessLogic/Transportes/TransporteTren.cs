using Domain.Interfaces.Transporte;

namespace BusinessLogic.Transportes
{
    public class TransporteTren : ITransporte
    {
        private int iCostoEnvioxKm = 5;
        private int iVelocidadEntrega = 80;
        public double ObtenerCostoEnvio(double dMargenUtilidad, double dDistancia)
        {
            double dCostoTotal = (iCostoEnvioxKm * dDistancia * (1 + (dMargenUtilidad / 100)));

            return dCostoTotal;
        }

        public double ObtenerTiempoEntrega(double dDistancia)
        {
            double dHoras = (dDistancia / iVelocidadEntrega);

            return dHoras;
        }
    }
}
