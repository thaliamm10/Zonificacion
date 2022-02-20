using System.Collections.Generic;
using System.Threading.Tasks;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Datos.CompendioNormas.Repositorios.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Configuraciones.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Jazani.ICL.Datos.CompendioNormas.Repositorios.Implementaciones
{
    public class NormaInteresModuloRepositorio: ICLRepositorio<NormaInteresModulo,long>, INormaInteresModuloRepositorio
    {
        public NormaInteresModuloRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) 
            : base(unidadDeTrabajo, configuracion)
        {
        }

        public async Task<List<NormaInteresModulo>> BuscarPorFiltros(
            string norma, long id_naturaleza, 
            string fecha_publicacion_inicio, 
            string fecha_publicacion_fin
            )
        {
            var response = await UnidadDeTrabajo.NormaInteresModulos
                .Include(t => t.NormaInteres)
                .Include(te => te.Modulo)
                .ToListAsync();

            return response;
        }
    }
}