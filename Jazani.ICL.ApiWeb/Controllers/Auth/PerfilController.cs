using Jazani.Comunes.Base.ApiWeb.Auth.Atributos;
using Jazani.Comunes.Base.ApiWeb.Base;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.Auth.Perfiles.Dtos;
using Jazani.ICL.Servicios.Auth.Perfiles.Servicios.Abstracciones;
using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jazani.ICL.ApiWeb.Controllers.Auth
{
       [Route("api/Auth/[controller]")]
    [ApiController]
    public class PerfilController : ApiControladorBase
    {
        private readonly IPerfilServicio _perfilServicio;
        public PerfilController(
                                IPerfilServicio perfilServicio
                               )
        {
            _perfilServicio = perfilServicio;
        }

        [HttpPost("Crear")]
        [RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> CrearAsync(PerfilDto peticion)
        {
            var operacion = await _perfilServicio.CrearAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Listar")]
        [RequiereAcceso()]
        public async Task<List<PerfilDto>> ListarAsync()
        {
            var operacion = await _perfilServicio.ListarAsync();
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
    }
}
