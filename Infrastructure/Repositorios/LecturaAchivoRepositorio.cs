using Domain.Interfaces.Repositorios;
using System.Collections.Generic;
using System.IO;

namespace Infrastructure.Repositorios
{
    public class LecturaAchivoRepositorio : ILecturaAchivoRepositorio
    {
        public List<string> LeerAchivo(string cPath)
        {
            List<string> lstPedidos = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(cPath))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        lstPedidos.Add(line);
                    }
                }

                return lstPedidos;
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("No se encontró la dirección del archivo.");
            }

        }
    }
}
