using Jazani.ICL.Datos.Auth.Entidades;
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
    public class PersonaRepositorio : ICLRepositorio<Persona, long>, IPersonaRepositorio
    {
        public PersonaRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(unidadDeTrabajo, configuracion) { }
        
        public async Task<Persona> BuscarPorDocumentoAsync(string documento)
        => await UnidadDeTrabajo.Personas.Where(x => x.Documento == documento).FirstOrDefaultAsync();

        public async Task<Persona> BuscarPorUsuarioAsync(string nombreUsuario)
       => await UnidadDeTrabajo.Personas
                .Include(e => e.Usuario)
                .Where(e => e.Usuario.NombreUsuario == nombreUsuario).FirstOrDefaultAsync();

     
    }
}
