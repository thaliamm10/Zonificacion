using Jazani.ICL.Datos.Infraestructura.Configuraciones.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Implementaciones;
using Jazani.ICL.Datos.Zonificacion.Entidades;
using Jazani.ICL.Datos.Zonificacion.Repositorios.Abstracciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Zonificacion.Repositorios.Implementaciones
{
    public class ZonificacionParametroRepositorio : ICLRepositorio<ZonificacionParametro, long>, IZonificacionParametroRepositorio

    {
        public ZonificacionParametroRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(unidadDeTrabajo, configuracion) { }

        public override async Task<ZonificacionParametro> BuscarPorIdYNoBorradoAsync(long id)
            => await UnidadDeTrabajo.ZonificacionParametros.Where(e => e.Id == id && e.Estado == 1).FirstOrDefaultAsync();

        public override async Task<ZonificacionParametro> BuscarPorIdAsync(long id)
            => await UnidadDeTrabajo.ZonificacionParametros.Where(e => e.Id == id ).FirstOrDefaultAsync();

        public async Task<ZonificacionParametro> BuscarPorZonificacionAsync(string zonificacion)
            => await UnidadDeTrabajo.ZonificacionParametros.Where(x => x.Zonificacion == zonificacion).FirstOrDefaultAsync();


        public async Task<List<ZonificacionParametro>> ListarAsync()
            => await UnidadDeTrabajo.ZonificacionParametros.Where(e => e.Estado == 1)
                .Include(e=>e.TipoNormativa)
                .Include(e=>e.Ubigeo)
                .Include(e=>e.Sector)
                .ToListAsync();

        public async Task<Tuple<List<ZonificacionParametro>, int>> ListarPaginadoAsync(string orden, int start, int length, 
            string codigo, string zonificacion,string abreviatura, string numNormativa, long idTipoNormativa, long codUbigeo)
        {
            var query = UnidadDeTrabajo.ZonificacionParametros
                .Where(e =>
                    e.Estado == 1
                    && (string.IsNullOrWhiteSpace(zonificacion) || e.Zonificacion.StartsWith(zonificacion))
                );


            var total = query.Count();

            switch (orden)
            {
                case "id":
                    query = query.OrderBy(e => e.Id);
                    break;
                case "id DESC":
                    query = query.OrderByDescending(e => e.Id);
                    break;
                case "zonificacion":
                    query = query.OrderBy(e => e.Zonificacion);
                    break;
                case "zonificacion DESC":
                    query = query.OrderByDescending(e => e.Zonificacion);
                    break;
            }

            query = query.Skip(start).Take(length);
            var resultados = await query.ToListAsync();
            return new Tuple<List<ZonificacionParametro>, int>(resultados, total);
        }

      
}