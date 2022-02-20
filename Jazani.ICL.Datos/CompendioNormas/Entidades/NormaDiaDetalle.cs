using System;
using System.Collections.Generic;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo
{
    public class NormaDiaDetalle
    {
        public long Id { get; set; }
        public long IdNormaDia { get; set; }
        public string Nombre { get; set; }
        public string Sumilla { get; set; }
        public int Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public virtual NormaDia NormaDia { get; set; }

        // 
        public virtual ICollection<NormaInteres> NormaInteres { get; set; }
        public NormaDiaDetalle()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }

    }
}