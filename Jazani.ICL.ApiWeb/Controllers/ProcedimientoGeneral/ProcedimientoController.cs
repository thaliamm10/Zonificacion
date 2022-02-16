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
    public class ProcedimientoController : ApiControladorBase
    {
        private readonly IProcedimientoServicio _procedimientoServicio;

        public ProcedimientoController(
                IProcedimientoServicio procedimientoServicio
            )
        {
            _procedimientoServicio = procedimientoServicio;
        }

        [HttpGet("Listar")]
        public async Task<List<ProcedimientoDto>> ListarAsync()
        {
            return null;
        }

        [HttpPost("Crear")]
        public async Task<RespuestaSimpleDto<String>> CrearAsync(ProcedimientoDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            throw new NotImplementedException();
        }
    }
    
}
