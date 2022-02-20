using Jazani.Comunes.DatosEF.Infraestructura.Contexto.Implementaciones;
using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Datos.Auth.Entidades.Mapeo;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Datos.General.Entidades.Mapeo;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Jazani.ICL.Datos.ProcedimientoGeneral.Entidades;
using Jazani.ICL.Datos.ProcedimientoGeneral.Entidades.Mapeo;
using Jazani.ICL.Datos.Zonificacion.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jazani.ICL.Datos.CompendioNormas;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo;
using Jazani.ICL.Datos.Zonificacion.Entidades.Mapeo;

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
        public DbSet<Autoridad> Autoridades { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<EstadoNorma> EstadoNormas { get; set; }
        public DbSet<Modulos> Modulos { get; set; }
        public DbSet<Naturalezas> Naturalezas { get; set; }
        public DbSet<NormaDia> NormaDias { get; set; }
        public DbSet<NormaDiaDetalle> NormaDiaDetalles { get; set; }
        public DbSet<NormaDiaDocumento> NormaDiaDocumentos { get; set; }
        public DbSet<NormaInteres> NormaInteress { get; set; }
        public DbSet<NormaInteresDocumento> NormaInteresDocumentos { get; set; }
        public DbSet<NormaInteresModulo> NormaInteresModulos { get; set; }
        public DbSet<ZonificacionParametroNormaInteres> ZonificacionParametroNormaInteress { get; set; }
        public DbSet<TipoProcedimiento> TipoProcedimientos { get; set; }
        public DbSet<TipoActividad> TipoActividads { get; set; }
        public DbSet<Ubigeo> Ubigeos { get; set; }
        public DbSet<Sector> Sectores { get; set; }
        public DbSet<Procedimiento> Procedimientos { get; set; }

        public DbSet<Tipo_Norma> Tipo_Normas { get; set; }
        public DbSet<ZonificacionParametro> ZonificacionParametros { get ; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.HasDefaultSchema("SISGESPRE");
            modelBuilder.ApplyConfiguration(new UsuarioMapeo());
            modelBuilder.ApplyConfiguration(new PerfilMapeo());
            modelBuilder.ApplyConfiguration(new DocumentoIdentidadMapeo());
            modelBuilder.ApplyConfiguration(new PersonaMapeo());
            modelBuilder.ApplyConfiguration(new AreaMapeo());
            modelBuilder.ApplyConfiguration(new TipoProcedimientoMapeo());
            modelBuilder.ApplyConfiguration(new TipoActividadMapeo());
            modelBuilder.ApplyConfiguration(new UbigeoMapeo());
            modelBuilder.ApplyConfiguration(new SectorMapeo());
            modelBuilder.ApplyConfiguration(new ProcedimientoMapeo());
            modelBuilder.ApplyConfiguration(new Tipo_NormaMapeo());

            modelBuilder.ApplyConfiguration(new AutoridadMapeo());
            modelBuilder.ApplyConfiguration(new DocumentoMapeo());
            modelBuilder.ApplyConfiguration(new EstadoNormaMapeo());
            modelBuilder.ApplyConfiguration(new ModulosMapeo());
            modelBuilder.ApplyConfiguration(new NaturalezaMapeo());
            modelBuilder.ApplyConfiguration(new NormaDiaMapeo());
            modelBuilder.ApplyConfiguration(new NormaDiaDetalleMapeo());
            modelBuilder.ApplyConfiguration(new NormaDiaDocumentoMapeo());
            modelBuilder.ApplyConfiguration(new NormaInteresMapeo());
            modelBuilder.ApplyConfiguration(new NormaInteresDocumentoMapeo());
            modelBuilder.ApplyConfiguration(new NormaInteresModuloMapeo());

            modelBuilder.ApplyConfiguration(new ZonificacionParametroMapeo());
            modelBuilder.ApplyConfiguration(new ZonificacionParametroNormaInteresMapeo());

        }
    }
}