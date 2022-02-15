using Jazani.Comunes.Base.ApiWeb.Base;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Datos.ProcedimientoGeneral.Entidades;
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
    public class TipoProcedimientoController : ApiControladorBase
    {
        private readonly ITipoProcedimientoServicio _tipoProcedimientoServicio;
        public TipoProcedimientoController(
                                ITipoProcedimientoServicio tipoProcedimientoServicio
                               )
        {
            _tipoProcedimientoServicio = tipoProcedimientoServicio;
        }

        [HttpPost("Crear")]
        //[RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> CrearAsync(TipoProcedimientoDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            var operacion = await _tipoProcedimientoServicio.CrearOActualizarAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpPut("Actualizar/{idCifrado}")]
        //[RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> ActualizarAsync(string idCifrado, TipoProcedimientoDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            peticion.Id = idCifrado;
            var operacion = await _tipoProcedimientoServicio.CrearOActualizarAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpDelete("Eliminar/{idCifrado}")]
        //[RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> EliminarAsync(string idCifrado)
        {
            var operacion = await _tipoProcedimientoServicio.EliminarAsync(idCifrado);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Obtener/{idCifrado}")]
        //[RequiereAcceso()]
        public async Task<TipoProcedimientoDto> ObtenerAsync(string idCifrado)
        {
            var operacion = await _tipoProcedimientoServicio.ObtenerAsync(idCifrado);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Listar")]
        //[RequiereAcceso()]
        public async Task<List<TipoProcedimientoDto>> ListarAsync()
        {
            var operacion = await _tipoProcedimientoServicio.ListarAsync();
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
    }
}
