using Jazani.Comunes.Base.ApiWeb.Base;
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

        [HttpGet("Listar")]
        public async Task<List<TipoActividadDto>> ListarAsync()
        {
            var operacion = await _tipoActividadServicio.ListarAsync();
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
        [HttpPost("Registrar")]
        public async Task<TipoActividadDto> RegistrarAsync(TipoActividadDto tipoActividadDto)
        {
            var operacion = await _tipoActividadServicio.RegistrarAsync(tipoActividadDto);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
        [HttpDelete("Eliminar/{id}")]
        public async Task<TipoActividadDto> EliminarAsync(String id)
        {
            var operacion = await _tipoActividadServicio.EliminarAsync(id);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
    }
}
