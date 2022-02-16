using Jazani.Comunes.Base.ApiWeb.Auth.Atributos;
using Jazani.Comunes.Base.ApiWeb.Base;
using Jazani.ICL.Servicios.General.Ubigeo.Dto;
using Jazani.ICL.Servicios.General.Ubigeos.Servicios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Jazani.ICL.ApiWeb.Controllers.General
{   
    [Route("api/general/[controller]")]
    [ApiController]
    public class UbigeoController : ApiControladorBase
       
    {
        private readonly IUbigeoServicio _ubigeoServicio;

        public UbigeoController( IUbigeoServicio ubigeoServicio)
        {
            _ubigeoServicio = ubigeoServicio;
        }
        [HttpGet("Listar")]
        [RequiereAcceso()]
        public async Task<List<UbigeoDto>> ListarAsync()
        {
            var operacion = await _ubigeoServicio.ListarAsync();
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
    }

}
