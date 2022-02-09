using Jazani.ICL.Datos.General.Entidades;
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
            builder.ToTable("USUARIO");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID_USUARIO");
            builder.Property(e => e.NombreUsuario).HasColumnName("NOMBRE_USUARIO").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Clave).HasColumnName("CLAVE").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.ClaveSalt).HasColumnName("CLAVE_SALT").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.IdPerfil).HasColumnName("ID_PERFIL").IsRequired();
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(e => e.Estado).HasColumnName("ESTADO");
            builder.HasOne(e => e.Perfil).WithMany(b => b.Usuario).HasForeignKey(c => c.IdPerfil);
            //builder.HasOne(a => a.Persona).WithOne(b => b.Usuario).HasForeignKey<Persona>(b => b.Id);
        }
    }
}
