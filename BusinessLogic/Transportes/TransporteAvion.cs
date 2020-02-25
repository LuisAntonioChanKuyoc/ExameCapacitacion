using Domain.Interfaces.Transporte;

namespace BusinessLogic.Transportes
{
    public class TransporteAvion : ITransporte
    {
        private int iCostoEnvioxKm = 10;
        private int iVelocidadEntrega = 600;

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
