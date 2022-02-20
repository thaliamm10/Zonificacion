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
    public class ProcedimientoRepositorio : ICLRepositorio<Procedimiento, int>, IProcedimientoRepositorio
    {
        public ProcedimientoRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(unidadDeTrabajo, configuracion) { }
        public override Task<Procedimiento> BuscarPorIdAsync(int id)
        {
            return base.BuscarPorIdAsync(id);
        }

        public override Task<Procedimiento> BuscarPorIdYNoBorradoAsync(int id)
        {
            return base.BuscarPorIdYNoBorradoAsync(id);
        }

        public async Task<List<Procedimiento>> ListarAsync(string nombre, int estado)
        {
            List<Procedimiento> response = new List<Procedimiento>();

            if (nombre == "ALL")
            {
                response = await UnidadDeTrabajo.Procedimientos
                    .Include(t => t.TipoProcedimiento)
                    .Where(e => e.Estado == estado)
                    .ToListAsync();
            } else
            {
                response = await UnidadDeTrabajo.Procedimientos
                    .Include(t => t.TipoProcedimiento)
                    .Where(e => e.Nombre == nombre && e.Estado == estado)
                    .ToListAsync();
            }
            

            return response;
        }
    }
}
