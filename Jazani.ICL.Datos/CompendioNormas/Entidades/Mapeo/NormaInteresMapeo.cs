using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo
{
    public class NormaInteresMapeo : IEntityTypeConfiguration<NormaInteres>
    {
        public void Configure(EntityTypeBuilder<NormaInteres> builder)
        {
            builder.ToTable("NORMA_INTERES");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_NORMA_INTERES");
            builder.Property(t => t.IdNormaDiaDetalle).HasColumnName("ID_NORMA_DIA_DETALLE");
            builder.Property(t => t.Nombre).HasColumnName("NOMBRE");
            builder.Property(t => t.Sumilla).HasColumnName("SUMILLA");
            builder.Property(t => t.IdUsuario).HasColumnName("ID_USUARIO");
            builder.Property(t => t.EsNormaInterna).HasColumnName("ES_NORMA_INTERNA");
            builder.Property(t => t.FechaPublicacion).HasColumnName("FECHA_PUBLICACION");
            builder.Property(t => t.FechaVigencia).HasColumnName("FECHA_VIGENCIA");
            builder.Property(t => t.IdTipoNorma).HasColumnName("ID_TIPO_NORMA");
            builder.Property(t => t.IdNaturaleza).HasColumnName("ID_NATURALEZA");
            builder.Property(t => t.IdAutoridad).HasColumnName("ID_AUTORIDAD");
            builder.Property(t => t.PaginasInteres).HasColumnName("PAGINAS_INTERES");
            builder.Property(t => t.observacion).HasColumnName("OBSERVACION");
            builder.Property(t => t.IdArea).HasColumnName("ID_AREA");
            builder.Property(t => t.IdEstadoNorma).HasColumnName("ID_ESTADO_NORMA");
            builder.Property(t => t.IdNormaDerogado).HasColumnName("ID_NORMA_DEROGADO");
            builder.Property(t => t.ArticuloNormaDerogado).HasColumnName("ARTICULO_NORMA_DEROGADO");
            builder.Property(t => t.ObservacionNormaDerogado).HasColumnName("OBSERVACION_NORMA_DEROGADO"); ;
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");

            //
            builder.HasOne(e => e.NormaDiaDetalle)
                .WithMany(b => b.NormaInteres)
                .HasForeignKey(c => c.IdNormaDiaDetalle);

            builder.HasOne(e => e.Usuario)
                .WithMany(b => b.NormaInteres)
                .HasForeignKey(c => c.IdUsuario);

            builder.HasOne(e => e.TipoNorma)
                .WithMany(b => b.NormaInteres)
                .HasForeignKey(c => c.IdTipoNorma);

            builder.HasOne(e => e.Naturaleza)
                .WithMany(b => b.NormaInteres)
                .HasForeignKey(c => c.IdNaturaleza);

            builder.HasOne(e => e.Autoridad)
                .WithMany(b => b.NormaInteres)
                .HasForeignKey(c => c.IdAutoridad);

            builder.HasOne(e => e.Area)
                .WithMany(b => b.NormaInteres)
                .HasForeignKey(c => c.IdArea);

            builder.HasOne(e => e.EstadoNorma)
                .WithMany(b => b.NormaInteres)
                .HasForeignKey(c => c.IdEstadoNorma);

      
        }
    }
}

