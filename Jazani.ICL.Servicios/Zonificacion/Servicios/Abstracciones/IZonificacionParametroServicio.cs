using System.Collections.Generic;
using System.Threading.Tasks;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.Zonificacion.Dtos;

namespace Jazani.ICL.Servicios.Zonificacion.Servicios.Abstracciones
{
    public interface IZonificacionParametroServicio
    {
        Task<OperacionDto<RespuestaSimpleDto<string>>> CrearOActualizarAsync(ZonificacionParametroDto peticion);
        Task<OperacionDto<RespuestaSimpleDto<string>>> EliminarAsync(string idZonificacionParametroCifrado);
        Task<OperacionDto<ZonificacionParametroDto>> ObtenerAsync(string idZonificacionParametroCifrado);
        Task<OperacionDto<List<ZonificacionParametroDto>>> ListarAsync();
        Task<OperacionDto<JQueryDatatableDto<ZonificacionParametroDto>>> ListarPaginado(ZonificacionParamtroPaginadoDto peticion);
    }
}