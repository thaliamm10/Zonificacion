using System.Collections.Generic;
using System.Threading.Tasks;
using Jazani.Comunes.Base.ApiWeb.Base;
using Jazani.ICL.Datos.CompendioNormas.Repositorios.Abstracciones;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;
using Jazani.ICL.Servicios.CompendioNormas.Servicios.Abstracciones;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.ICL.ApiWeb.Controllers.Zonificacion
{
    [Route("api/Zonificacion/[controller]")]
    [ApiController]
    public class NormaInteresController : ApiControladorBase
    {
        private readonly INormaInteresFiltroServicio _normaInteresFiltroServicio;
        private readonly INormaInteresModuloServicio _normaInteresModuloServicio;
        public NormaInteresController(
            INormaInteresFiltroServicio normaInteresFiltroServicio,
            INormaInteresModuloServicio normaInteresModuloServicio
        )
        {
            _normaInteresFiltroServicio = normaInteresFiltroServicio;
            _normaInteresModuloServicio = normaInteresModuloServicio;
        }

        [HttpGet("Listar")]
        // [RequiereAcceso()]
        public async Task<List<NormaInteresFiltroDto>> ListarAsync(string norma, string id_naturaleza,string id_modulo,
            string fecha_publicacion_inicio, string fecha_publicacion_fin)
        {
            var operacion = await _normaInteresFiltroServicio
                .ListarAsync( norma,id_naturaleza,id_modulo,fecha_publicacion_inicio,fecha_publicacion_fin);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }

        [HttpGet("Listar2")]
        // [RequiereAcceso()]
        public async Task<List<NormaInteresModuloDto>> Listar2Async(string norma, string id_naturaleza, string id_modulo,
            string fecha_publicacion_inicio, string fecha_publicacion_fin)
        {
                           var operacion = await _normaInteresModuloServicio
                .ListarAsync(norma, id_naturaleza, id_modulo,fecha_publicacion_inicio, fecha_publicacion_fin);
            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }


    }
}
