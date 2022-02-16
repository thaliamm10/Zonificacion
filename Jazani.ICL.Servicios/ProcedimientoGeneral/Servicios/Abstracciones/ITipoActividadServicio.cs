using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.ProcedimientoGeneral.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.ProcedimientoGeneral.Servicios.Abstracciones
{
    public interface ITipoActividadServicio
    {
        Task<OperacionDto<RespuestaSimpleDto<string>>> CrearOActualizarAsync(TipoActividadDto peticion);
        Task<OperacionDto<RespuestaSimpleDto<string>>> EliminarAsync(string idTipoActividadCifrado);
        Task<OperacionDto<TipoActividadDto>> ObtenerAsync(string idTipoActividadCifrado);
        Task<OperacionDto<List<TipoActividadDto>>> ListarAsync();
    }
}
