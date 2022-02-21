using Jazani.ICL.Servicios.General.Modulo.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Dtos
{
    public class NormaInteresModuloDto
    {
        public string Id { get; set; }
        public string IdModulo { get; set; }

        public string IdNormaInteres { get; set; }

        public int Estado { get; set; }

        public ModulosDto Modulo { get; set; }
        public NormaInteresListaDto NormaInteres { get; set; } 
    }
}