using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.ProcedimientoGeneral.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.ProcedimientoGeneral.Servicios.Abstracciones
{
    public interface IProcedimientoServicio
    {
        Task<OperacionDto<RespuestaSimpleDto<String>>> CrearOActualizarAsync(ProcedimientoDto procedimientoDto);
        Task<OperacionDto<List<ProcedimientoDto>>> ListarAsync(String nombre, int estado);
    }
}
