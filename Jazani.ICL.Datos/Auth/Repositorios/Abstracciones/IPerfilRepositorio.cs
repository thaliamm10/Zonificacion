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
        Task<List<Perfil>> ListarAsync();
    }
}
