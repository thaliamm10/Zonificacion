using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo
{
    public class NormaInteresModuloMapeo : IEntityTypeConfiguration<NormaInteresModulo>
    {
        public void Configure(EntityTypeBuilder<NormaInteresModulo> builder)
        {
            builder.ToTable("NORMA_INTERES_MODULO");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_NORMA_INTERES");
            builder.Property(e => e.IdModulo).HasColumnName("ID_MODULO");
            builder.Property(e => e.IdNormaInteres).HasColumnName("ID_NORMA_INTERES");
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");

            builder.HasOne(e => e.Modulo)
                .WithMany(b => b.NormaInteresModulo)
                .HasForeignKey(c => c.IdModulo);
            builder.HasOne(e => e.NormaInteres)
                .WithMany(b => b.NormaInteresModulo)
                .HasForeignKey(c => c.IdNormaInteres);
        }
    }
}
 