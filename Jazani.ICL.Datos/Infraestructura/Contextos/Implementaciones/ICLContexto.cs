using Jazani.Comunes.DatosEF.Infraestructura.Contexto.Implementaciones;
using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Datos.Auth.Entidades.Mapeo;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Datos.General.Entidades.Mapeo;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Infraestructura.Contextos.Implementaciones
{
    public class ICLContexto : EFDbContext, IICLUnidadDeTrabajo
    {
        public ICLContexto(DbContextOptions opciones) : base(opciones) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Perfil> Perfiles { get; set; }

        public DbSet<DocumentoIdentidad> DocumentoIdentidad { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.HasDefaultSchema("SISGESPRE");
            modelBuilder.ApplyConfiguration(new UsuarioMapeo());

            modelBuilder.ApplyConfiguration(new PerfilMapeo());

            modelBuilder.ApplyConfiguration(new DocumentoIdentidadMapeo());
            modelBuilder.ApplyConfiguration(new PersonaMapeo());
            modelBuilder.ApplyConfiguration(new AreaMapeo());

        }
    }
}
