using Jazani.Comunes.Base.ApiWeb.Base;
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

        [HttpGet("Listar")]
        //[RequiereAcceso()]
        public async Task<List<TipoProcedimientoDto>> ListarAsync()
        {
            var operacion = await _tipoProcedimientoServicio.ListarAsync();
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Listar/{start}/{length}")]
        public async Task<List<TipoProcedimientoDto>> ListarPaginadoAsync(int start, int length)
        {
            var operacion = await _tipoProcedimientoServicio.ListarPaginadoAsync(start, length);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpPost("Registrar")]
        public async Task<List<TipoProcedimientoDto>> RegistrarAsync(TipoProcedimientoDto tipoProcedimientoDto)
        {
            var operacion = await _tipoProcedimientoServicio.RegistrarAsync(tipoProcedimientoDto);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
    }
}
