using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using Jazani.ICL.Servicios.General.Personas.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Usuarios.Servicios.Abstracciones
{
    public interface IUsuarioServicio
    {
        Task<OperacionDto<List<UsuarioDto>>> ListarAsync();
        Task<OperacionDto<RespuestaSimpleDto<string>>> CrearAsync(UsuarioDto peticion);
        Task<OperacionDto<RespuestaSimpleDto<string>>> CrearPersonaUsuarioAsync(PersonaDto peticion);
    }
}
