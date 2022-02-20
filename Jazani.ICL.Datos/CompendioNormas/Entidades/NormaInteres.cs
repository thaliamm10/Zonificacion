using System;
using System.Collections.Generic;
using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo;
using Jazani.ICL.Datos.General.Entidades;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades
{
    public class NormaInteres
    {
        public long Id { get; set; }

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

        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }

        public virtual NormaDiaDetalle NormaDiaDetalle { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Tipo_Norma TipoNorma { get; set; }

        public virtual Naturaleza Naturaleza { get; set; }

        public virtual Autoridad Autoridad { get; set; }

        public virtual Area Area { get; set; }

        public virtual EstadoNorma EstadoNorma { get; set; }

        public virtual NormaInteres NormaDerogada { get; set; }

        //
        public virtual ICollection<NormaInteresModulo> NormaInteresModulo { get; set; }
        
        public NormaInteres()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}

// ID_NORMA_INTERES, ID_NORMA_DIA_DETALLE, NOMBRE, SUMILLA, ID_USUARIO, ES_NORMA_INTERNA, FECHA_PUBLICACION,
//FECHA_VIGENCIA, ID_TIPO_NORMA, ID_NATURALEZA, ID_AUTORIDAD, PAGINAS_INTERES, OBSERVACION, ID_AREA,
//ID_ESTADO_NORMA, ID_NORMA_DEROGADO, ARTICULO_NORMA_DEROGADO, OBSERVACION_NORMA_DEROGADO, FECHA_REGISTRO, ESTADO