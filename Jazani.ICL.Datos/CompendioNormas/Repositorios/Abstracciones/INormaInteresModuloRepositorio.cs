using System.Collections.Generic;
using System.Threading.Tasks;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Abstracciones;

namespace Jazani.ICL.Datos.CompendioNormas.Repositorios.Abstracciones
{
    public interface INormaInteresModuloRepositorio
        :IICLRepositorio<NormaInteresModulo, long>
    {
        Task<List<NormaInteresModulo>> BuscarPorFiltros(
            string norma, long id_naturaleza,
            string fecha_publicacion_inicio,
            string fecha_publicacion_fin
        );
    }
}