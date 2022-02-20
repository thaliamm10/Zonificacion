using System.Collections.Generic;
using System.Threading.Tasks;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.Zonificacion.Dtos;

namespace Jazani.ICL.Servicios.Zonificacion.Servicios.Abstracciones
{
    public interface IZonificacionParametroNormaInteresServicio
    {
        Task<OperacionDto<RespuestaSimpleDto<string>>> CrearOActualizarAsync(ZonificacionParametroNormaInteresDto peticion);
        Task<OperacionDto<RespuestaSimpleDto<string>>> EliminarAsync(string idZonificacionParametroCifrado);
        Task<OperacionDto<ZonificacionParametroNormaInteresDto>> ObtenerAsync(string idZonificacionParametroCifrado);
        Task<OperacionDto<List<ZonificacionParametroNormaInteresDto>>> ListarAsync();
        Task<OperacionDto<JQueryDatatableDto<ZonificacionParametroNormaInteresDto>>> ListarPaginado(ZonificacionParamtroPaginadoDto peticion);
    }
}