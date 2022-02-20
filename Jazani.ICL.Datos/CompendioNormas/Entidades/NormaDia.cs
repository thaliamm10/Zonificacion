using System;
using System.Collections.Generic;
using Jazani.ICL.Datos.General.Entidades;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo
{
    public class NormaDia
    {
        public long Id { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public long IdTipoNorma { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }

        public virtual Tipo_Norma TipoNorma { get; set; }

        public virtual ICollection<NormaDiaDetalle> NormaDiaDetalle { get; set; }

        public virtual ICollection<NormaDiaDocumento> NormaDiaDocumento { get; set; }


        public NormaDia()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}