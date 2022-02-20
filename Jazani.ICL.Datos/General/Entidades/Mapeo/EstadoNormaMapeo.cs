using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.ICL.Datos.General.Entidades.Mapeo
{
    public class EstadoNormaMapeo : IEntityTypeConfiguration<EstadoNorma>
    {
        public void Configure(EntityTypeBuilder<EstadoNorma> builder)
        {
            builder.ToTable("ESTADO_NORMA");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_ESTADO_NORMA");
            builder.Property(e => e.Codigo).HasColumnName("CODIGO").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
        }
    }
}