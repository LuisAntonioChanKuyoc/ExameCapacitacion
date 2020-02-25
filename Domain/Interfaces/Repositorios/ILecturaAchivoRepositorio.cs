using System.Collections.Generic;

namespace Domain.Interfaces.Repositorios
{
    public interface ILecturaAchivoRepositorio
    {
        List<string> LeerAchivo(string cPath);
    }
}
