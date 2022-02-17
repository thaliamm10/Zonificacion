using System;
using System.Collections.Generic;

namespace Jazani.ICL.Datos.Zonificacion.Entidades
{
    public class TipoNormativa
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<ZonificacionParametro> ZonificacionParametro { get; set; }
        public TipoNormativa()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}