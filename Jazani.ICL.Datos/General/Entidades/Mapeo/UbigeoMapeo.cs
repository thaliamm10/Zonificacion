using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.ICL.Datos.General.Entidades.Mapeo
{
    class UbigeoMapeo : IEntityTypeConfiguration<Ubigeo>
    {
        public void Configure(EntityTypeBuilder<Ubigeo> builder)
        {
            builder.ToTable("UBIGEO");
            builder.HasKey(t => t.CodigoUbigeo);
            builder.Property(t => t.CodigoUbigeo).HasColumnName("CODIGO_UBIGEO").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.CodigoPadre).HasColumnName("CODIGO_PADRE").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.CodigoParcial).HasColumnName("CODIGO_PARCIAL").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Nombre).HasColumnName("NOMBRE").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Nivel).HasColumnName("NIVEL");
            builder.Property(e => e.NombreCompleto).HasColumnName("NOMBRE_COMPLETO").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
        }
    }
}
