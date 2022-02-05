using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Auth.Entidades.Mapeo
{
    public class UsuarioMapeo : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO", "DEVELOPER");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID");
            builder.Property(e => e.Email).HasColumnName("EMAIL").IsUnicode(false).HasMaxLength(80);
            builder.Property(e => e.Clave).HasColumnName("CONTRASENIA").IsUnicode(false).HasMaxLength(200);
            builder.Property(e => e.Nombres).HasColumnName("NOMBRES").IsUnicode(false).HasMaxLength(80);
            builder.Property(e => e.ApellidoPaterno).HasColumnName("PATERNO").IsUnicode(false).HasMaxLength(80);
            builder.Property(e => e.ApellidoMaterno).HasColumnName("MATERNO").IsUnicode(false).HasMaxLength(80);
            builder.Property(e => e.EmailAlterno).HasColumnName("EMAIL_ALTERNO").IsUnicode(false).HasMaxLength(80);
            builder.Property(e => e.Documento).HasColumnName("NUMERO_DOCUMENTO").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Telefono).HasColumnName("TELEFONO").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Direccion).HasColumnName("DIRECCION").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.IdPerfil).HasColumnName("ID_PERFIL").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
            builder.HasOne(e => e.Perfil).WithMany(b => b.Usuario).HasForeignKey(c => c.IdPerfil);
        }
    }
}
