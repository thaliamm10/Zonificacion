using System;
using System.ComponentModel.DataAnnotations;
using Jazani.ICL.Datos.Zonificacion.Entidades;

namespace Jazani.ICL.Servicios.Zonificacion.Dtos
{
    public class ZonificacionParametroDto
    {
        // ID_ZONIFICACION_PARAMETRO
        public string Id { get; set; }
        // CODIGO
        [Required(ErrorMessage = "Codigo es requerido")]
        public string Codigo { get; set; }
        // ZONIFICACION
        public string Zonificacion { get; set; }
        // ABREVIATURA
        public string Abreviatura { get; set; }
        // FK CODIGO_UBIGEO
        public string CodigoUbigeo { get; set; }
        // FK ID_TIPO_NORMA
        public long IdTipoNorma { get; set; }
        // TIPO_NORMA
        public TipoNormativa TipoNormativa { get; set; }
        public long TipoNorma { get; set; }
        // NUMERO_NORMATIVA
        public string NumeroNormativa { get; set; }
        // FK ID_SECTOR
        public long IdSector { get; set; }
        // DENSIDAD_NETA
        public string DensidadNeta { get; set; }
        // AREA_LOTE_MIN_NORMATIVO
        public string AreaLoteMinNormativo { get; set; }
        // FRENTE_LOTE_MIN_NORMATIVO
        public string FrenteLoteMinNormativo { get; set; }
        //ALTURA_MAX_EDIFICACION_PISO
        public string AlturaMaxEdificacionPiso { get; set; }
        // ALTURA_MAX_EDIFICACION
        public string AlturaMaxEdificacion { get; set; }
        //PORCENTAJE_MIN_AREA_LIBRE
        public string PorcentajeMinAreaLibre { get; set; }
        // USO_PERMITIDO
        public string UsoPermitido { get; set; }
        // REQUIERE_ESTACIONAMIENTO
        public string RequiereEstacionamiento { get; set; }
        // COEFICIENTE_EDIFICACION
        public string CoeficienteEdificacion { get; set; }
        // USO_COMPATIBLES
        public string UsoCompatibles { get; set; }
        // NOTA
        public string Nota { get; set; }
        // OBSERVACION
        public string Observacion { get; set; }
        // ESTADO_CULMINADO
        public long EstadoCulminado { get; set; }
        // FECHA_REGISTRO
        public DateTime FechaRegistro { get; set; }
        // ESTADO
        public int Estado { get; set; }

    }
}