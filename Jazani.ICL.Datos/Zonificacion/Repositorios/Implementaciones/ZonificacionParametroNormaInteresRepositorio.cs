using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jazani.ICL.Datos.Infraestructura.Configuraciones.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Implementaciones;
using Jazani.ICL.Datos.Zonificacion.Entidades;
using Jazani.ICL.Datos.Zonificacion.Repositorios.Abstracciones;
using Microsoft.EntityFrameworkCore;

namespace Jazani.ICL.Datos.Zonificacion.Repositorios.Implementaciones
{
    public class ZonificacionParametroNormaInteresRepositorio:ICLRepositorio<ZonificacionParametroNormaInteres,long>, IZonificacionParametroNormaInteresRepositorio
    {

        public ZonificacionParametroNormaInteresRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(unidadDeTrabajo, configuracion)
        {
        }

        public override async Task<ZonificacionParametroNormaInteres> BuscarPorIdYNoBorradoAsync(long id)
            => await UnidadDeTrabajo.ZonificacionParametroNormaInteress.Where(e => e.Id == id && e.Estado == 1)
                .FirstOrDefaultAsync();

        public override async Task<ZonificacionParametroNormaInteres> BuscarPorIdAsync(long id)
            => await UnidadDeTrabajo.ZonificacionParametroNormaInteress.Where(e => e.Id == id).FirstOrDefaultAsync();

        public async Task<ZonificacionParametroNormaInteres> BuscarPorIdNormaInteresAsync(long IdNormaInteres)
              => await UnidadDeTrabajo.ZonificacionParametroNormaInteress.Where(x => x.IdNormaInteres == IdNormaInteres)
                  .FirstOrDefaultAsync();

          public async Task<List<ZonificacionParametroNormaInteres>> ListarAsync()
            => await UnidadDeTrabajo.ZonificacionParametroNormaInteress.Where(e => e.Estado == 1)
                .Include(e => e.ZonificacionParametro)
                .Include(e => e.NormaInteres)
                .ToListAsync();

 

        public Task<Tuple<List<ZonificacionParametroNormaInteres>, int>> ListarPaginadoAsync(string orden, int start, int length, string zonificacion = null)
        {
            throw new NotImplementedException();
        }
    }
}