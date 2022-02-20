using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.ICL.Datos.General.Entidades.Mapeo
{
    public class DocumentoMapeo : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder.ToTable("DOCUMENTO");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_DOCUMENTO");
            builder.Property(e => e.Nombre).HasColumnName("NOMBRE").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Descripcion).HasColumnName("DESCRIPCION").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.Contenido).HasColumnName("CONTENIDO");
            builder.Property(e => e.MineType).HasColumnName("MIME_TYPE");
            builder.Property(e => e.Extencion).HasColumnName("EXTENCION");
            builder.Property(e => e.NombreOriginal).HasColumnName("NOMBRE_ORIGINAL");
            builder.Property(e => e.UbicacionFisica).HasColumnName("UBICACION_FISICA");
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
        }
    }
}