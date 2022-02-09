using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Auth.Repositorios.Abstracciones
{
    public interface IPerfilRepositorio : IICLRepositorio<Perfil, long>
    {
        Task<Perfil> BuscarPorNombreAsync(string nombre);
        Task<List<Perfil>> ListarAsync();
        Task<Tuple<List<Perfil>, int>> ListarPaginadoAsync(string orden, int start, int length, string nombre = null);
    }
}
