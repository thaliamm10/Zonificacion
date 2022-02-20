using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.General.Entidades.Mapeo
{
    class SectorMapeo : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.ToTable("SECTOR");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_SECTOR");
            builder.Property(e => e.Codigo).HasColumnName("CODIGO").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("DESCRIPCION").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
        }
    }
}
