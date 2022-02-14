using Jazani.Comunes.Base.ApiWeb.Auth.Atributos;
using Jazani.Comunes.Base.ApiWeb.Base;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using Jazani.ICL.Servicios.Auth.Usuarios.Servicios.Abstracciones;
using Jazani.ICL.Servicios.General.Personas.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jazani.ICL.ApiWeb.Controllers.Auth
{
    [Route("api/Auth/[controller]")]
    [ApiController]
    public class UsuarioController : ApiControladorBase
    {
        private readonly IUsuarioServicio _usuarioServicio;
        public UsuarioController(
                                 IUsuarioServicio usuarioServicio
                                )
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpPost("Crear")]
        //[RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> CrearAsync(UsuarioDto peticion)
        {
            var operacion = await _usuarioServicio.CrearAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        } 
        
        [HttpPost("CrearPersonaUsuario")]
        [RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> CrearPersonaUsuarioAsync(PersonaDto peticion)
        {
            var operacion = await _usuarioServicio.CrearPersonaUsuarioAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Listar")]
        [RequiereAcceso()]
        public async Task<List<UsuarioDto>> ListarAsync()
        {
            var operacion = await _usuarioServicio.ListarAsync();
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
    }
}
