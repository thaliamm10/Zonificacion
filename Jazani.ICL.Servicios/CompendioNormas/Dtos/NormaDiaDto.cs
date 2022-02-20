using System;
using Jazani.ICL.Servicios.General.Tipo_Norma.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Dtos
{
    public class NormaDiaDto
    {
        public string Id { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public long IdTipoNorma { get; set; }

        public TipoNormaDto TipoNorma { get; set; }

    }
}