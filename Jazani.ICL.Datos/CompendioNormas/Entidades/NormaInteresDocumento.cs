using System;
using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades
{
    public class NormaInteresDocumento
    {
        public long Id { get; set; }
        public long IdDocumento { get; set; }
        public long IdNormaDiaDocumento { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        //Relaciones
        public virtual Documento Documento { get; set; }
        public virtual NormaDiaDocumento NormaDiaDocumento { get; set; }
        public virtual Usuario Usuario { get; set; }
        //
        public NormaInteresDocumento()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
