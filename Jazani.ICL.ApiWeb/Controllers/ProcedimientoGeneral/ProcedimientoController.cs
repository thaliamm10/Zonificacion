using Jazani.Comunes.Base.ApiWeb.Base;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.ProcedimientoGeneral.Dtos;
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
        [HttpGet("Listar")]
        public async Task<List<ProcedimientoDto>> ListarAsync()
        {
            return null;
        }
    }

    //[HttpPost("Crear")]
    //public async Task<RespuestaSimpleDto<String>> CrearAsync(ProcedimientoDto procedimientoDto)
    //{

    //    throw new NotImplementedException();
    //}
}
