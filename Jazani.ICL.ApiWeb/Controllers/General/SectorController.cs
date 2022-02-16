using Jazani.Comunes.Base.ApiWeb.Auth.Atributos;
using Jazani.Comunes.Base.ApiWeb.Base;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.General.Sectores.Dtos;
using Jazani.ICL.Servicios.General.Sectores.Servicios.Abstracciones;
//using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jazani.ICL.ApiWeb.Controllers.General
{
    [Route("api/general/[controller]")]
    [ApiController]
    public class SectorController : ApiControladorBase
    {
        private readonly ISectorServicio _sectorServicio;
        public SectorController(
                                ISectorServicio sectorServicio
                               )
        {
            _sectorServicio = sectorServicio;
        }

        /*[HttpPost("Crear")]
        [RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> CrearAsync(SectorDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            var operacion = await _sectorServicio.CrearOActualizarAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpPut("Actualizar/{idCifrado}")]
        [RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> ActualizarAsync(string idCifrado, SectorDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            peticion.Id = idCifrado;
            var operacion = await _sectorServicio.CrearOActualizarAsync(peticion);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpDelete("Eliminar/{idCifrado}")]
        [RequiereAcceso()]
        public async Task<RespuestaSimpleDto<string>> EliminarAsync(string idCifrado)
        {
            var operacion = await _sectorServicio.EliminarAsync(idCifrado);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Obtener/{idCifrado}")]
        [RequiereAcceso()]
        public async Task<SectorDto> ObtenerAsync(string idCifrado)
        {
            var operacion = await _sectorServicio.ObtenerAsync(idCifrado);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }*/

        [HttpGet("Listar")]
        [RequiereAcceso()]
        public async Task<List<SectorDto>> ListarAsync()
        {
            var operacion = await _sectorServicio.ListarAsync();
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
    }
}
