using Jazani.ICL.Datos.Infraestructura.Repositorios.Abstracciones;
using Jazani.ICL.Datos.ProcedimientoGeneral.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.ProcedimientoGeneral.Repositorios.Abstracciones
{
    public interface ITipoActividadRepositorio : IICLRepositorio<TipoActividad, int>
    {
        Task<List<TipoActividad>> ListarAsync();
        Task<TipoActividad> BuscarPorNombreAsync(string nombre);
    }
}
