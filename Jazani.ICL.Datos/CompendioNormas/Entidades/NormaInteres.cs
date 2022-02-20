using System;
using System.Collections.Generic;
using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Datos.Zonificacion.Entidades;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades
{
    public class NormaInteres
    {
        public long Id { get; set; }

        public long IdNormaDiaDetalle { get; set; }
        public string Nombre { get; set; }
        public string Sumilla { get; set; }
        public long? IdUsuario { get; set; }
        public int EsNormaInterna { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaVigencia { get; set; }
        public long? IdTipoNorma { get; set; }
        public long IdNaturaleza { get; set; }
        public long? IdAutoridad { get; set; }
        public string PaginasInteres { get; set; }
        public string observacion { get; set; }
        public int? IdArea { get; set; }
        public long? IdEstadoNorma { get; set; }
        public long? IdNormaDerogado { get; set; }

        public string ArticuloNormaDerogado { get; set; }

        public string ObservacionNormaDerogado { get; set; }

        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        // Relaciones
        public virtual NormaDiaDetalle NormaDiaDetalle { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Tipo_Norma TipoNorma { get; set; }

        public virtual Naturalezas Naturaleza { get; set; }

        public virtual Autoridad Autoridad { get; set; }

        public virtual Area Area { get; set; }

        public virtual EstadoNorma EstadoNorma { get; set; }


        //
        public virtual ICollection<NormaInteresModulo> NormaInteresModulo { get; set; }

        public virtual ICollection<ZonificacionParametroNormaInteres> ZonificacionParametroNormaInteres { get; set; }
        public NormaInteres()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
