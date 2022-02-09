using Jazani.ICL.Datos.General.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Auth.Entidades
{
    public class Usuario
    {
        public long Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string ClaveSalt { get; set; }
        public long  IdPerfil { get; set; }
        public DateTime  FechaRegistro { get; set; }
        public int  Estado { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual Persona Persona { get; set; }
        public Usuario()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
