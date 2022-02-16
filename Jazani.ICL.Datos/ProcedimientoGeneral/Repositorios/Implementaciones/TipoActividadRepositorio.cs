using Jazani.ICL.Datos.Infraestructura.Configuraciones.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Implementaciones;
using Jazani.ICL.Datos.ProcedimientoGeneral.Entidades;
using Jazani.ICL.Datos.ProcedimientoGeneral.Repositorios.Abstracciones;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.ProcedimientoGeneral.Repositorios.Implementaciones
{
    public class TipoActividadRepositorio : ICLRepositorio<TipoActividad, int>, ITipoActividadRepositorio
    {
        public TipoActividadRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(unidadDeTrabajo, configuracion) { }
        public override async Task<TipoActividad> BuscarPorIdAsync(int id)
        => await UnidadDeTrabajo.TipoActividads.Where(e => e.Id == id).FirstOrDefaultAsync();

        public override async Task<TipoActividad> BuscarPorIdYNoBorradoAsync(int id)
        => await UnidadDeTrabajo.TipoActividads.Where(e => e.Id == id && e.Estado == 1).FirstOrDefaultAsync();

        public async Task<TipoActividad> BuscarPorNombreAsync(string nombre)
        => await UnidadDeTrabajo.TipoActividads.Where(x => x.Nombre == nombre).FirstOrDefaultAsync();

        public async Task<List<TipoActividad>> ListarAsync()
        => await UnidadDeTrabajo.TipoActividads.Where(e => e.Estado == 1).ToListAsync();
    }
}
