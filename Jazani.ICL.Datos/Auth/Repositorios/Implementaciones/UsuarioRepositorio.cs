using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Datos.Auth.Repositorios.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Configuraciones.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Auth.Repositorios.Implementaciones
{
    public class UsuarioRepositorio : ICLRepositorio<Usuario, int>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(unidadDeTrabajo, configuracion) { }

        public async Task<Usuario> BuscarPorUsuarioAsync(string usuario)
        => await UnidadDeTrabajo.Usuarios.Where(x => x.Nombre == usuario).FirstOrDefaultAsync();
    }
}
