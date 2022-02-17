using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.General.Entidades.Mapeo
{
    class Tipo_NormaMapeo : IEntityTypeConfiguration<Tipo_Norma>
    {
        public void Configure(EntityTypeBuilder<Tipo_Norma> builder)
        {
            builder.ToTable("TIPO_NORMA");
            builder.HasKey(t => t.ID_TIPO_NORMA);
            builder.Property(t => t.ID_TIPO_NORMA).HasColumnName("ID_TIPO_NORMA");
            builder.Property(e => e.Codigo).HasColumnName("CODIGO").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("DESCRIPCION").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
        }
    }
}
