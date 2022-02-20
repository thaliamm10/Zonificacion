using Jazani.ICL.Datos.General.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo;

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

        public virtual ICollection<NormaInteres> NormaInteres { get; set; }
        public virtual ICollection<NormaInteresDocumento> NormaInteresDocumento { get; set; }
        public virtual ICollection<NormaDiaDocumento> NormaDiaDocumento { get; set; }

        public Usuario()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
