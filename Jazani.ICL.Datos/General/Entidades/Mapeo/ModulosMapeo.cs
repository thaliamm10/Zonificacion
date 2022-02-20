using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.ICL.Datos.General.Entidades.Mapeo
{
    public class ModulosMapeo : IEntityTypeConfiguration<Modulos>
    {
        public void Configure(EntityTypeBuilder<Modulos> builder)
        {
            builder.ToTable("MODULO");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_MODULO");
            builder.Property(e => e.Codigo).HasColumnName("CODIGO").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.Descripcion).HasColumnName("DESCRIPCION").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
        }
    }
}