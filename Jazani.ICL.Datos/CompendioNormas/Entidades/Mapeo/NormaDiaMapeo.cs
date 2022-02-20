using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo
{
    public class NormaDiaMapeo: IEntityTypeConfiguration<NormaDia>
    {
        public void Configure(EntityTypeBuilder<NormaDia> builder)
        {
            builder.ToTable("NORMA_DIA");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_NORMA_DIA");
            builder.Property(e => e.FechaPublicacion).HasColumnName("FECHA_PUBLICACION");
            builder.Property(e => e.IdTipoNorma).HasColumnName("ID_TIPO_NORMA");
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");

            builder.HasOne(e => e.TipoNorma)
                .WithMany(b => b.NormaDia)
                .HasForeignKey(c => c.IdTipoNorma);

        }
    }
}
