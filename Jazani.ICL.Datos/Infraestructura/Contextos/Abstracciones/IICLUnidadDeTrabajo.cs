using Jazani.Comunes.DatosEF.Infraestructura.Contexto.Abstracciones;
using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Datos.General.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones
{
    public interface IICLUnidadDeTrabajo : IEFUnidadDeTrabajo
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Perfil> Perfiles { get; set; }

        public DbSet<DocumentoIdentidad> DocumentoIdentidad { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Area> Areas { get; set; }
<<<<<<< HEAD
        public DbSet<Ubigeo> Ubigeos { get; set; }
=======
        public DbSet<Sector> Sectores { get; set; }
>>>>>>> 8149886ef9c09d4652780be818292e5fb6878c71
    }
}
