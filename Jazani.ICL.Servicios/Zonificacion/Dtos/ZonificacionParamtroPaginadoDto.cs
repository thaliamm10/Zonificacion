using System.ComponentModel.DataAnnotations;

namespace Jazani.ICL.Servicios.Zonificacion.Dtos
{
    public class ZonificacionParamtroPaginadoDto
    {
        [Required(ErrorMessage = "Página es requerido")]
        public int? Pagina { get; set; }


        [Required(ErrorMessage = "Tamaño Página es requerido")]
        public int? TamanioPagina { get; set; }


        public string LlaveOrdenamiento { get; set; }

        public int Draw { get; set; }

        public string Zonificacion { get; set; }
    }
}