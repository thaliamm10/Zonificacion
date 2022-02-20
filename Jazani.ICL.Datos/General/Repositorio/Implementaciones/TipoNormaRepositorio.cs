using Jazani.Comunes.DatosBase.Infraestructura.Repositorios.Abstracciones;
using Jazani.Comunes.DatosEF.Infraestructura.Repositorios.Abstracciones;
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
  
    public class TipoNormaRepositorio : ICLRepositorio<Tipo_Norma, long>, ITipoNormaRepositorio
    {
        public TipoNormaRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(unidadDeTrabajo, configuracion) { }

        public async Task<Tipo_Norma> BuscarPorCodigoAsync(string codigo)
            => await UnidadDeTrabajo.Tipo_Normas.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();
        public async Task<List<Tipo_Norma>> ListarAsync()
            => await UnidadDeTrabajo.Tipo_Normas.Where(e => e.Estado == 1).ToListAsync();
    }
}
