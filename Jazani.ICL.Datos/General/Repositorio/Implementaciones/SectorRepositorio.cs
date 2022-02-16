using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Datos.Auth.Repositorios.Abstracciones;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Datos.General.Repositorio.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Configuraciones.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.General.Repositorio.Implementaciones
{
    public class SectorRepositorio : ICLRepositorio<Sector, long>, ISectorRepositorio
    {
        public SectorRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(unidadDeTrabajo, configuracion) { }
        public override async Task<Sector> BuscarPorIdYNoBorradoAsync(long id)
        => await UnidadDeTrabajo.Sectores.Where(e => e.Id == id && e.Estado == 1).FirstOrDefaultAsync();

        public async Task<Sector> BuscarPorCodigoAsync(string codigo)
        => await UnidadDeTrabajo.Sectores.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();

        public async Task<List<Sector>> ListarAsync()
        => await UnidadDeTrabajo.Sectores.Where(e => e.Estado == 1).ToListAsync();
    }
}
