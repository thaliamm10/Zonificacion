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

        public async Task<List<NormaInteres>> BuscarPorFiltros(string norma, long id_naturaleza, long id_modulo,
            string fecha_publicacion_inicio,
            string fecha_publicacion_fin)
        {
            var response_i = UnidadDeTrabajo.NormaInteress
                    .Include(t => t.Naturaleza)
                    .Include(te => te.NormaInteresModulo)
                    .ThenInclude(te => te.Modulo)
                    .AsQueryable();


            response_i = response_i.Where(e => e.Estado == 1);

            if (!string.IsNullOrWhiteSpace(norma))
            {
                response_i = response_i.Where(e => e.Nombre.Contains(norma));
            }
            if (id_naturaleza != 0)
            {
                response_i = response_i.Where(e => e.IdNaturaleza == id_naturaleza);
            }
            if (id_modulo != 0)
            {
                response_i = response_i.Where(e => (e.NormaInteresModulo.Select(t => t.Modulo.Id).Where(p=>p.Equals(id_modulo))).FirstOrDefault()==id_modulo );
            }
            if (!(string.IsNullOrWhiteSpace(fecha_publicacion_inicio)) && !(string.IsNullOrWhiteSpace(fecha_publicacion_fin)))
            {
                response_i = response_i.Where(e => e.FechaPublicacion >= DateTime.Parse(fecha_publicacion_inicio)
                                                   && e.FechaPublicacion <= DateTime.Parse(fecha_publicacion_fin));
            }

            var datos = await response_i.ToListAsync();
            return datos;
        }

    }
}