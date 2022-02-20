using System.Collections.Generic;
using System.Threading.Tasks;
using Jazani.Comunes.Base.ApiWeb.Auth.Atributos;
using Jazani.Comunes.Base.ApiWeb.Base;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.Zonificacion.Dtos;
using Jazani.ICL.Servicios.Zonificacion.Servicios.Abstracciones;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.ICL.ApiWeb.Controllers.Zonificacion
{
    [Route("api/Zonificacion/[controller]")]
    [ApiController]
    public class ZonificacionParametroNormaInteresController : ApiControladorBase
    {
        private readonly IZonificacionParametroNormaInteresServicio _zonificacionParametroNormaInteresServicio;
        public ZonificacionParametroNormaInteresController(
            IZonificacionParametroNormaInteresServicio zonificacionParametroNormaInteresServicio
        )
        {
            _zonificacionParametroNormaInteresServicio = zonificacionParametroNormaInteresServicio;
        }

        [HttpPost("Crear")]
        [RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> CrearAsync(ZonificacionParametroNormaInteresDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            var operacion = await _zonificacionParametroNormaInteresServicio.CrearOActualizarAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpPut("Actualizar/{idCifrado}")]
        [RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> ActualizarAsync(string idCifrado, ZonificacionParametroNormaInteresDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            peticion.Id = idCifrado;
            var operacion = await _zonificacionParametroNormaInteresServicio.CrearOActualizarAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpDelete("Eliminar/{idCifrado}")]
        [RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> EliminarAsync(string idCifrado)
        {
            var operacion = await _zonificacionParametroNormaInteresServicio.EliminarAsync(idCifrado);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Obtener/{idCifrado}")]
        [RequiereAcceso()]
        public async Task<ZonificacionParametroNormaInteresDto> ObtenerAsync(string idCifrado)
        {
            var operacion = await _zonificacionParametroNormaInteresServicio.ObtenerAsync(idCifrado);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Listar")]
        // [RequiereAcceso()]
        public async Task<List<ZonificacionParametroNormaInteresDto>> ListarAsync()
        {
            var operacion = await _zonificacionParametroNormaInteresServicio.ListarAsync();
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpPost("ListarPaginado")]
        [RequiereAcceso()]
        public async Task<JQueryDatatableDto<ZonificacionParametroNormaInteresDto>> ListarPaginadoAsync(ZonificacionParamtroPaginadoDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            var operacion = await _zonificacionParametroNormaInteresServicio.ListarPaginado(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
    }
}
