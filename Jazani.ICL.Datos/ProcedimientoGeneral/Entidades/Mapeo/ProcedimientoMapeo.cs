using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.ProcedimientoGeneral.Entidades.Mapeo
{
    public class ProcedimientoMapeo : IEntityTypeConfiguration<Procedimiento>
    {
        public void Configure(EntityTypeBuilder<Procedimiento> builder)
        {
            builder.ToTable("PROCEDIMIENTO");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_PROCEDIMIENTO");
            builder.Property(e => e.Nombre).HasColumnName("NOMBRE");
            builder.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
            builder.Property(e => e.IdTipoProcedimiento).HasColumnName("ID_TIPO_PROCEDIMIENTO").IsRequired();

            builder.HasOne(e => e.TipoProcedimiento).WithMany(b => b.Procedimiento).HasForeignKey(c => c.IdTipoProcedimiento);

        }
    }
}
