using System;
using Jazani.ICL.Servicios.General.Naturaleza.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Dtos
{
    public class NormaInteresListaDto
    {
        public string Id { get; set; }
    
        public string Nombre { get; set; }
        public string Sumilla { get; set; }

        public DateTime FechaPublicacion { get; set; }
        public long IdNaturaleza { get; set; }
        public NaturalezaDto Naturaleza { get; set; }
    }
}