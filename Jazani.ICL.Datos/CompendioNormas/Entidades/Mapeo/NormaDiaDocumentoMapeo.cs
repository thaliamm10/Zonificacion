using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo
{
    public class NormaDiaDocumentoMapeo : IEntityTypeConfiguration<NormaDiaDocumento>
    {
        public void Configure(EntityTypeBuilder<NormaDiaDocumento> builder)
        {
            builder.ToTable("NORMA_DIA_DOCUMENTO");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_NORMA_DIA_DOCUMENTO");
            builder.Property(e => e.IdNormaDia).HasColumnName("ID_NORMA_DIA");
            builder.Property(e => e.IdDocumento).HasColumnName("ID_DOCUMENTO");
            builder.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");

            builder.HasOne(e => e.NormaDia)
                .WithMany(b => b.NormaDiaDocumento)
                .HasForeignKey(c => c.IdNormaDia);

            builder.HasOne(e => e.Documento)
                .WithMany(b => b.NormaDiaDocumento)
                .HasForeignKey(c => c.IdDocumento);

            builder.HasOne(e => e.Usuario)
                .WithMany(b => b.NormaDiaDocumento)
                .HasForeignKey(c => c.IdUsuario);
        }
    }
}