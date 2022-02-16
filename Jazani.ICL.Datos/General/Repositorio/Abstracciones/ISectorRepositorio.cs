using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.General.Repositorio.Abstracciones
{
    public interface ISectorRepositorio : IICLRepositorio<Sector, long>
    {
        //Task<Sector> BuscarPorCodigoAsync(string codigo);
        Task<Sector> BuscarPorCodigoAsync(string codigo);
        Task<List<Sector>> ListarAsync();
        //Task<Tuple<List<Sector>, int>> ListarPaginadoAsync(string orden, int start, int length, string nombre = null);
    }
}
