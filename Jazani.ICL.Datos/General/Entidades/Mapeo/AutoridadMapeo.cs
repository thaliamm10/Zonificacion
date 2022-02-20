using Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.ICL.Datos.General.Entidades.Mapeo
{
    public class AutoridadMapeo : IEntityTypeConfiguration<Autoridad>
    {
        public void Configure(EntityTypeBuilder<Autoridad> builder)
        {
            builder.ToTable("AUTORIDAD");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_AUTORIDAD");
            builder.Property(e => e.Codigo).HasColumnName("CODIGO").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.Descripcion).HasColumnName("DESCRIPCION").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
        }
    }
}