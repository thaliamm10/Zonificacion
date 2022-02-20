using Jazani.Comunes.DatosEF.Infraestructura.Contexto.Abstracciones;
using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Datos.ProcedimientoGeneral.Entidades;
using Microsoft.EntityFrameworkCore;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Datos.Zonificacion.Entidades;

namespace Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones
{
    public interface IICLUnidadDeTrabajo : IEFUnidadDeTrabajo
    {
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

        public DbSet<ZonificacionParametro> ZonificacionParametros { get; set; }

        public DbSet<ZonificacionParametroNormaInteres> ZonificacionParametroNormaInteress { get; set; }
        public DbSet<TipoProcedimiento> TipoProcedimientos { get; set; }
        public DbSet<TipoActividad> TipoActividads { get; set; }
        public DbSet<Ubigeo> Ubigeos { get; set; }
        public DbSet<Sector> Sectores { get; set; }
        public DbSet<Procedimiento> Procedimientos { get; set; }
        public DbSet<Tipo_Norma> Tipo_Normas { get; set; }
    }
}
