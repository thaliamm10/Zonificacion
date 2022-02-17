using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.ICL.Datos.Zonificacion.Entidades.Mapeo
{
    public class TipoNormativaMapeo : IEntityTypeConfiguration<TipoNormativa>
    {
        public void Configure(EntityTypeBuilder<TipoNormativa> builder)
        {
            builder.ToTable("TIPO_NORMA");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_PERFIL");
            builder.Property(e => e.Codigo).HasColumnName("CODIGO").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Descripcion).HasColumnName("DESCRIPCION").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
        }
    }
}