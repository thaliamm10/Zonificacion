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

        [HttpPost("Guardar")]
        [RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> GuardarAsync(PerfilDto peticion)
        {
            var operacion = await _perfilServicio.CrearOActualizarAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpDelete("Eliminar/{id}")]
        [RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> EliminarAsync(string id)
        {
            var operacion = await _perfilServicio.EliminarAsync(id);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Obtener/{id}")]
        [RequiereAcceso()]
        public async Task<PerfilDto> ObtenerAsync(string id)
        {
            var operacion = await _perfilServicio.ObtenerAsync(id);
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
