using System;
using System.Collections.Generic;
using Jazani.ICL.Datos.Auth.Entidades;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo
{
    public class NormaDiaDocumento
    {
        public long Id { get; set; }
        public long IdNormaDia { get; set; }
        
        public long IdDocumento { get; set; }
     
        public long IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        /// Realaciones

        public virtual NormaDia NormaDia { get; set; }

        public virtual Documento Documento { get; set; }

        public virtual Usuario Usuario { get; set; }

        //
        public virtual ICollection<NormaInteresDocumento> NormaInteresDocumento { get; set; }



        public NormaDiaDocumento()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
