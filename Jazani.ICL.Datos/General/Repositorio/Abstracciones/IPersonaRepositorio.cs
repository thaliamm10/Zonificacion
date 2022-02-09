using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.General.Repositorio.Abstracciones
{
    public interface IPersonaRepositorio : IICLRepositorio<Persona, long>
    {
        Task<Persona> BuscarPorDocumentoAsync(string documento);
        Task<Persona> BuscarPorUsuarioAsync(string nombreUsuario);
    }
}
