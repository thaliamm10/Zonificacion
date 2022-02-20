using System;
using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using Jazani.ICL.Servicios.General;
using Jazani.ICL.Servicios.General.EstadoNorma.Dtos;
using Jazani.ICL.Servicios.General.Naturaleza.Dtos;
using Jazani.ICL.Servicios.General.Personas.Dtos;
using Jazani.ICL.Servicios.General.Tipo_Norma.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Dtos
{
    public class NormaInteresDto
    {
        public string Id { get; set; }
        public long IdNormaDiaDetalle { get; set; }
        public string Nombre { get; set; }
        public string Sumilla { get; set; }
        public string IdUsuario { get; set; }
        public int EsNormaInterna { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaVigencia { get; set; }
        public long IdTipoNorma { get; set; }
        public long IdNaturaleza { get; set; }
        public long IdAutoridad { get; set; }
        public string PaginasInteres { get; set; }
        public string observacion { get; set; }
        public long IdArea { get; set; }
        public long IdEstadoNorma { get; set; }
        public long IdNormaDerogado { get; set; }

        public string ArticuloNormaDerogado { get; set; }

        public string ObservacionNormaDerogado { get; set; }


        public NormaDiaDetalleDto NormaDiaDetalle { get; set; }

        public UsuarioDto Usuario { get; set; }

        public TipoNormaDto TipoNorma { get; set; }

        public NaturalezaDto Naturaleza { get; set; }

        public AutoridadDto Autoridad { get; set; }

        public AreaDto Area { get; set; }

        public EstadoNormaDto EstadoNorma { get; set; }

    }
}