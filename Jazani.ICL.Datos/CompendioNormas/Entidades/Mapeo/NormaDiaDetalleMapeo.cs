using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo
{
    public class NormaDiaDetalleMapeo : IEntityTypeConfiguration<NormaDiaDetalle>
    {
        public void Configure(EntityTypeBuilder<NormaDiaDetalle> builder)
        {
            builder.ToTable("NORMA_DIA_DETALLE");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_NORMA_DIA_DETALLE");
            builder.Property(e => e.IdNormaDia).HasColumnName("ID_NORMA_DIA");
            builder.Property(e => e.Nombre).HasColumnName("NOMBRE");
            builder.Property(e => e.Sumilla).HasColumnName("SUMILLA");
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");

            builder.HasOne(e => e.NormaDia)
                .WithMany(b => b.NormaDiaDetalle)
                .HasForeignKey(c => c.IdNormaDia);
        }
    }
}
