using System.Collections.Generic;
using System.Threading.Tasks;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Servicios.Abstracciones
{
    public interface INormaInteresModuloServicio
    {
        Task<OperacionDto<List<NormaInteresModuloDto>>> ListarAsync(string norma, 
            string id_naturaleza,string id_modulo, string fecha_inicio, string fecha_fin);
    }
}