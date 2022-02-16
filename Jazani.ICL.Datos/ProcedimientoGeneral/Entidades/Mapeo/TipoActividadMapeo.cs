using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.ProcedimientoGeneral.Entidades.Mapeo
{
    public class TipoActividadMapeo : IEntityTypeConfiguration<TipoActividad>
    {
        public void Configure(EntityTypeBuilder<TipoActividad> builder)
        {
            builder.ToTable("TIPO_ACTIVIDAD");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_TIPO_ACTIVIDAD");
            builder.Property(e => e.Nombre).HasColumnName("NOMBRE").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
        }
    }
}
