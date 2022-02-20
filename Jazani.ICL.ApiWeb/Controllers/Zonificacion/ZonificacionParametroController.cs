using System.Collections.Generic;
using System.Threading.Tasks;
using Jazani.Comunes.Base.ApiWeb.Auth.Atributos;
using Jazani.Comunes.Base.ApiWeb.Base;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.Zonificacion.Dtos;
using Jazani.ICL.Servicios.Zonificacion.Servicios.Abstracciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.ICL.ApiWeb.Controllers.Zonificacion
{
    [Route("api/Zonificacion/[controller]")]
    [ApiController]
    public class ZonificacionParametroController : ApiControladorBase
    {
        private readonly IZonificacionParametroServicio _zonificacionParametroServicio;
        public ZonificacionParametroController(
            IZonificacionParametroServicio zonificacionParametroServicio
        )
        {
            _zonificacionParametroServicio = zonificacionParametroServicio;
        }

        // POST: ZonificacionParametro

        [HttpPost("Crear")]
       [RequiereAcceso()]

        public async Task<RespuestaSimpleDto<string>> CrearAsync(ZonificacionParametroDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            var operacion = await _zonificacionParametroServicio.CrearOActualizarAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpPut("Actualizar/{idCifrado}")]
        [RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> ActualizarAsync(string idCifrado, ZonificacionParametroDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            peticion.Id = idCifrado;
            var operacion = await _zonificacionParametroServicio.CrearOActualizarAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpDelete("Eliminar/{idCifrado}")]
        [RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> EliminarAsync(string idCifrado)
        {
            var operacion = await _zonificacionParametroServicio.EliminarAsync(idCifrado);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Obtener/{idCifrado}")] 
        [RequiereAcceso()]
        public async Task<ZonificacionParametroDto> ObtenerAsync(string idCifrado)
        {
            var operacion = await _zonificacionParametroServicio.ObtenerAsync(idCifrado);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
        [HttpGet("Listar")]
      // [RequiereAcceso()]
        public async Task<List<ZonificacionParametroDto>> ListarAsync()
        {
            var operacion = await _zonificacionParametroServicio.ListarAsync();
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
        [HttpPost("ListarPaginado")]
        [RequiereAcceso()]
        public async Task<JQueryDatatableDto<ZonificacionParametroDto>> ListarPaginadoAsync(ZonificacionParamtroPaginadoDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            var operacion = await _zonificacionParametroServicio.ListarPaginado(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
    }
}
