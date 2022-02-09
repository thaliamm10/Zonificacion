using Jazani.ICL.Datos.Auth.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.General.Entidades.Mapeo
{
    class PersonaMapeo : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("PERSONA");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_PERSONA");
            builder.Property(e => e.Nombre).HasColumnName("NOMBRES").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Paterno).HasColumnName("AP_PATERNO").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Materno).HasColumnName("AP_MATERNO").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Correo).HasColumnName("CORREO").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.IdDocumentoIdentidad).HasColumnName("ID_DOCUMENTO_IDENTIDAD").IsRequired();
            builder.Property(e => e.Documento).HasColumnName("NUMERO_DOCUMENTO").IsUnicode(false).HasMaxLength(30); ;
            builder.Property(e => e.Telefono).HasColumnName("TELEFONO").IsUnicode(false).HasMaxLength(30); ;
            builder.Property(e => e.Direccion).HasColumnName("DIRECCION").IsUnicode(false).HasMaxLength(500); ;
            builder.Property(e => e.IdArea).HasColumnName("ID_AREA");
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
            builder.HasOne(e => e.DocumentoIdentidad).WithMany(b => b.Persona).HasForeignKey(c => c.IdDocumentoIdentidad);
            builder.HasOne(e => e.Area).WithMany(b => b.Persona).HasForeignKey(c => c.IdArea);
            builder.HasOne(a => a.Usuario).WithOne(b => b.Persona).HasForeignKey<Usuario>(b => b.Id);
        }
    }
}
