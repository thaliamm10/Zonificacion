using Jazani.ICL.Datos.Infraestructura.Configuraciones.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Implementaciones;
using Jazani.ICL.Datos.ProcedimientoGeneral.Entidades;
using Jazani.ICL.Datos.ProcedimientoGeneral.Repositorios.Abstracciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.ProcedimientoGeneral.Repositorios.Implementaciones
{
    public class TipoProcedimientoRepositorio : ICLRepositorio<TipoProcedimiento, int>, ITipoProcedimientoRepositorio
    {
        public TipoProcedimientoRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(unidadDeTrabajo, configuracion) { }

        public async Task<List<TipoProcedimiento>> ListarAsync()
            => await UnidadDeTrabajo.TipoProcedimientos.Where(e => e.Estado == 1).ToListAsync();
    }
}
