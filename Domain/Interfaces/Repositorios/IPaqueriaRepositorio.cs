namespace Domain.Interfaces.Repositorios
{
    public interface IPaqueriaRepositorio
    {
        string ObtenerCostoEconomico(double _dDistancia, string _cTransporte, string _cPaqueteria, double dCostoAnterior);
    }
}
