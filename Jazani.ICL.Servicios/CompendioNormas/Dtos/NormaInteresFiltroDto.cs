using System;
using System.Collections.Generic;
using Jazani.ICL.Servicios.General.Modulo.Dtos;
using Jazani.ICL.Servicios.General.Naturaleza.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Dtos
{
    public class NormaInteresFiltroDto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Sumilla { get; set; }
        public DateTime FechaPublicacion { get; set; }

      //  public NormaInteresModuloSNDto NormaInteresModuloss { get; set; }
        public NaturalezaDto Naturaleza { get; set; }
        public List<ModulosDto> Modulo { get; set; }

    }

}