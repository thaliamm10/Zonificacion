using Jazani.ICL.Datos.General.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Zonificacion.Entidades
{
    public class ZonificacionParametro
    {
        public long Id { get; set; }
        public int IdZonificacionParametro { get; set; }
        public string Codigo { get; set; }
        public string Zonificacion { get; set; }
        public string Abreviatura { get; set; }
        public string CodigoUbigeo { get; set; }
        public int IdTipoNorma { get; set; }
        public string NumeroNormativa { get; set; }
        public int IdSector { get; set; }
        public string DensidadNeta { get; set; }
        public string AreaLoteMinNormativo { get; set; }
        public string FrenteLoteMinNormativo { get; set; }
        public string AlturaMaxEdificacionPiso { get; set; }
        public string AlturaMaxEdificacion { get; set; }
        public string PorcentajeMinAreaLibre { get; set; }
        public string UsoPermitido { get; set; }
        public string RequiereEstacionamiento { get; set; }
        public string CoeficienteEdificacion { get; set; }
        public string UsoCompatibles { get; set; }
        public string Nota { get; set; }
        public string Observacion { get; set; }
        public int EstadoCulminado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        public virtual Ubigeo Ubigeo { get; set; }
        //public virtual TipoNorma TipoNorma { get; set; }
        public virtual Sector Sector { get; set; }

        public ZonificacionParametro()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
