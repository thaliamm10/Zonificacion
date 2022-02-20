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
    public class UbigeoRepositorio : ICLRepositorio<Ubigeo, long>, IUbigeoRepositorio
    {
        public UbigeoRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(unidadDeTrabajo, configuracion) { }
     
        public async Task<Ubigeo> BuscarPorCodigoAsync(string codigo)
            => await UnidadDeTrabajo.Ubigeos.Where(x => x.CodigoPadre == codigo).FirstOrDefaultAsync();
        public async Task<List<Ubigeo>> ListarAsync()
            => await UnidadDeTrabajo.Ubigeos.Where(e => e.Estado == 1).ToListAsync();


    }
}
