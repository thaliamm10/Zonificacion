using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo
{
    public class NormaInteresDocumentoMapeo : IEntityTypeConfiguration<NormaInteresDocumento>
    {
        public void Configure(EntityTypeBuilder<NormaInteresDocumento> builder)
        {
            builder.ToTable("NORMA_INTERES_DOCUMENTO");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_NORMA_INTERES_DOCUMENTO");
            builder.Property(e => e.IdDocumento).HasColumnName("ID_DOCUMENTO");
            builder.Property(e => e.IdNormaInteres).HasColumnName("ID_NORMA_INTERES");
            builder.Property(e => e.IdNormaDiaDocumento).HasColumnName("ID_NORMA_DIA_DOCUMENTO");
            builder.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            builder.Property(e => e.FechaModificacion).HasColumnName("FECHA_MODIFICACION");
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");

            builder.HasOne(e => e.Documento)
                .WithMany(b => b.NormaInteresDocumento)
                .HasForeignKey(c => c.IdDocumento);

            builder.HasOne(e => e.NormaDiaDocumento)
                .WithMany(b => b.NormaInteresDocumento)
                .HasForeignKey(c => c.IdNormaDiaDocumento);

            builder.HasOne(e => e.Usuario)
                .WithMany(b => b.NormaInteresDocumento)
                .HasForeignKey(c => c.IdUsuario);
        }
    }
}