using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.ProcedimientoGeneral.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.ProcedimientoGeneral.Servicios.Abstracciones
{
    public interface ITipoProcedimientoServicio
    {
        Task<OperacionDto<RespuestaSimpleDto<string>>> CrearOActualizarAsync(TipoProcedimientoDto peticion);
        Task<OperacionDto<RespuestaSimpleDto<string>>> EliminarAsync(string idCifrado);
        Task<OperacionDto<TipoProcedimientoDto>> ObtenerAsync(string idCifrado);
        Task<OperacionDto<List<TipoProcedimientoDto>>> ListarAsync();
    }
}
