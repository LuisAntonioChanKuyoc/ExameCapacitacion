namespace Domain.Interfaces.Paqueterias
{
    public interface IPaqueterias
    {
        double ObtenerCostoxPedido(string cTransporte, double fDistancia);

        double ObtenerTiempoEntrega(double dDistancia);

    }
}
