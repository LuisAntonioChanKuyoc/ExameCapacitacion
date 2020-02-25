namespace Domain.Interfaces.Transporte
{
    public interface ITransporte
    {
        double ObtenerCostoEnvio(double dMargenUtilidad,double dDistancia);
        double ObtenerTiempoEntrega(double dDistancia);
    }
}
