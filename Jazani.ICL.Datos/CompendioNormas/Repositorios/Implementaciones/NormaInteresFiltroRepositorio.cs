using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Datos.CompendioNormas.Repositorios.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Configuraciones.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Jazani.ICL.Datos.CompendioNormas.Repositorios.Implementaciones
{
    public class NormaInteresFiltroRepositorio : ICLRepositorio<NormaInteres, long>, INormaInteresFiltroRepositorio

    {
        public NormaInteresFiltroRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(
            unidadDeTrabajo, configuracion)
        {
        }

        public async Task<List<NormaInteres>> BuscarPorFiltros(string norma, long id_naturaleza,
            string fecha_publicacion_inicio,
            string fecha_publicacion_fin)
        {
            var response = await UnidadDeTrabajo.NormaInteress
                .Include(t => t.Naturaleza)
                .Include(te => te.NormaInteresModulo).ThenInclude(te => te.Modulo)
                .ToListAsync();    
            //.Where(e => (string.IsNullOrWhiteSpace(norma) || e.Nombre.Contains(norma))
                //            && (string.IsNullOrWhiteSpace(id_naturaleza) || e.IdNaturaleza.Equals(id_naturaleza)
                //                && ((string.IsNullOrWhiteSpace(fecha_publicacion_inicio) && string.IsNullOrWhiteSpace(fecha_publicacion_fin)) || (e.FechaPublicacion >= DateTime.Parse(fecha_publicacion_inicio) && e.FechaPublicacion <= DateTime.Parse(fecha_publicacion_fin)))
                //            )).FirstOrDefaultAsync();

            //var response_i = UnidadDeTrabajo.NormaInteress.AsQueryable();

            //if (!string.isnullorwhitespace(norma))
            //{
            //    response_i = response_i.where(e => e.nombre.contains(norma));
            //}
            //if (id_naturaleza != null || id_naturaleza!=0)
            //{
            //    response_i = response_i.where(e => e.idnaturaleza == id_naturaleza);
            //}
            //if (!(string.isnullorwhitespace(fecha_publicacion_inicio)) && !(string.isnullorwhitespace(fecha_publicacion_fin)))
            //{
            //    response_i = response_i.where(e => e.fechapublicacion>=datetime.parse(fecha_publicacion_inicio) 
            //                                       && e.fechapublicacion<= datetime.parse(fecha_publicacion_fin));
            //}

            //var datos = await response_i.FirstOrDefaultAsync();
            return response;
        }

    }
}