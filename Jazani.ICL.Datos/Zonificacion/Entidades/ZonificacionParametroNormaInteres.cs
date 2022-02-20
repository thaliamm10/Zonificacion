using System;
using Jazani.ICL.Datos.CompendioNormas.Entidades;

namespace Jazani.ICL.Datos.Zonificacion.Entidades
{
    public class ZonificacionParametroNormaInteres
    {
        public long Id { get; set; }
        public long IdZonificacionParametro { get; set; }
        public long IdNormaInteres { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        public virtual NormaInteres NormaInteres { get; set; }
        public virtual ZonificacionParametro ZonificacionParametro { get; set; }
        public ZonificacionParametroNormaInteres()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
