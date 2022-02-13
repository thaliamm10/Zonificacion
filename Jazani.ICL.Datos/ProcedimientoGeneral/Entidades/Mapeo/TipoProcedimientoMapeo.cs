using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.ProcedimientoGeneral.Entidades.Mapeo
{
    class TipoProcedimientoMapeo : IEntityTypeConfiguration<TipoProcedimiento>
    {
        public void Configure(EntityTypeBuilder<TipoProcedimiento> builder)
        {
            builder.ToTable("TIPO_PROCEDIMIENTO");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_TIPO_PROCEDIMIENTO");
            builder.Property(e => e.Nombre).HasColumnName("NOMBRE").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
        }
    }
}
