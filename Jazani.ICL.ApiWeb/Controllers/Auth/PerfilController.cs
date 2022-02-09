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
    [Route("api/auth/[controller]")]
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
            VerificarIfEsBuenJson(peticion);
            var operacion = await _perfilServicio.CrearOActualizarAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpPut("Actualizar/{idCifrado}")]
        [RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> ActualizarAsync(string idCifrado,PerfilDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            peticion.Id = idCifrado;
            var operacion = await _perfilServicio.CrearOActualizarAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpDelete("Eliminar/{idCifrado}")]
        [RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> EliminarAsync(string idCifrado)
        {
            var operacion = await _perfilServicio.EliminarAsync(idCifrado);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Obtener/{idCifrado}")]
        [RequiereAcceso()]
        public async Task<PerfilDto> ObtenerAsync(string idCifrado)
        {
            var operacion = await _perfilServicio.ObtenerAsync(idCifrado);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Listar")]
        [RequiereAcceso()]
        public async Task<List<PerfilDto>> ListarAsync()
        {
            var operacion = await _perfilServicio.ListarAsync();
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpPost("ListarPaginado")]
        [RequiereAcceso()]
        public async Task<JQueryDatatableDto<PerfilDto>> ListarPaginadoAsync(PerfilPaginadoPeticionDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            var operacion = await _perfilServicio.ListarPaginado(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
    }
}
