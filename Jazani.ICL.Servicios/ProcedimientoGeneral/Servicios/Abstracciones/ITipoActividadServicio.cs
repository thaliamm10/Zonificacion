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
        Task<OperacionDto<List<TipoActividadDto>>> ListarAsync();
        Task<OperacionDto<TipoActividadDto>> RegistrarAsync(TipoActividadDto tipoActividadDto);
        Task<OperacionDto<TipoActividadDto>> EliminarAsync(String id);
    }
}
