using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.ICL.Datos.Zonificacion.Entidades.Mapeo
{
    public class ZonificacionParametroNormaInteresMapeo : IEntityTypeConfiguration<ZonificacionParametroNormaInteres>
    {
        public void Configure(EntityTypeBuilder<ZonificacionParametroNormaInteres> builder)
        {
            builder.ToTable("ZONIFICACION_PARAMETRO_NORMA_INTERES");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_ZONIFICACION_NORMA");
            builder.Property(t => t.IdZonificacionParametro).HasColumnName("ID_ZONIFICACION_PARAMETRO");
            builder.Property(t => t.IdNormaInteres).HasColumnName("ID_NORMA_INTERES");
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");

            builder.HasOne(e => e.ZonificacionParametro).WithMany(
                b => b.ZonificacionParametroNormaInteres).HasForeignKey(c
                => c.IdZonificacionParametro);
            builder.HasOne(e => e.NormaInteres).WithMany(
                b => b.ZonificacionParametroNormaInteres).HasForeignKey(c
                => c.IdNormaInteres);
        }
    }
}