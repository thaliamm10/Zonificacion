using Jazani.Comunes.Base.ApiWeb.Auth.Atributos;
using Jazani.Comunes.Base.ApiWeb.Base;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.ProcedimientoGeneral.Dtos;
using Jazani.ICL.Servicios.ProcedimientoGeneral.Servicios.Abstracciones;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jazani.ICL.ApiWeb.Controllers.ProcedimientoGeneral
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoActividadController : ApiControladorBase
    {
        private readonly ITipoActividadServicio _tipoActividadServicio;
        public TipoActividadController(
                                ITipoActividadServicio tipoActividadServicio
                               )
        {
            _tipoActividadServicio = tipoActividadServicio;
        }

        [HttpPost("Crear")]
        //[RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> CrearAsync(TipoActividadDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            var operacion = await _tipoActividadServicio.CrearOActualizarAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpPut("Actualizar/{idCifrado}")]
        //[RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> ActualizarAsync(string idCifrado, TipoActividadDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            peticion.Id = idCifrado;
            var operacion = await _tipoActividadServicio.CrearOActualizarAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpDelete("Eliminar/{idCifrado}")]
        //[RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> EliminarAsync(string idCifrado)
        {
            var operacion = await _tipoActividadServicio.EliminarAsync(idCifrado);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Obtener/{idCifrado}")]
        //[RequiereAcceso()]
        public async Task<TipoActividadDto> ObtenerAsync(string idCifrado)
        {
            var operacion = await _tipoActividadServicio.ObtenerAsync(idCifrado);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Listar")]
        //[RequiereAcceso()]
        public async Task<List<TipoActividadDto>> ListarAsync()
        {
            var operacion = await _tipoActividadServicio.ListarAsync();
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
    }
}
