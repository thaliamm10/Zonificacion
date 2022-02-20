using System;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;

namespace Jazani.ICL.Servicios.Zonificacion.Dtos
{
    public class ZonificacionParametroNormaInteresDto
    {

        public string Id { get; set; }
        public long IdZonificacionParametro { get; set; }
        public long IdNormaInteres { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }

        public  NormaInteresDto NormaInteres { get; set; }
        public ZonificacionParametroDto ZonificacionParametro { get; set; }

    }
}