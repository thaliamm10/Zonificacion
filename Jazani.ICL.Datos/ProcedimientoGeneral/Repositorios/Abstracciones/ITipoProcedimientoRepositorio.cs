using Jazani.ICL.Datos.Infraestructura.Repositorios.Abstracciones;
using Jazani.ICL.Datos.ProcedimientoGeneral.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.ProcedimientoGeneral.Repositorios.Abstracciones
{
    public interface ITipoProcedimientoRepositorio: IICLRepositorio<TipoProcedimiento, int>
    {
        Task<List<TipoProcedimiento>> ListarAsync();

        Task<List<TipoProcedimiento>> ListarPaginadoAsync(int start, int length);

        Task<Boolean> RegistrarAsync(TipoProcedimiento tipoProcedimiento);
    }
}
