using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.General.Entidades.Mapeo
{
    class DocumentoIdentidadMapeo: IEntityTypeConfiguration<DocumentoIdentidad>
    {
        public void Configure(EntityTypeBuilder<DocumentoIdentidad> builder)
        {
            builder.ToTable("DOCUMENTO_IDENTIDAD");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_DOCUMENTO_IDENTIDAD");
            builder.Property(e => e.Nombre).HasColumnName("NOMBRE").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Descripcion).HasColumnName("DESCRIPCION").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
        }
    }
}
