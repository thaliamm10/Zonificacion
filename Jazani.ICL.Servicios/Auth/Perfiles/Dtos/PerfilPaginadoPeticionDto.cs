using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Perfiles.Dtos
{
    public class PerfilPaginadoPeticionDto
    {
        [Required(ErrorMessage = "Página es requerido")]
        public int? Pagina { get; set; }


        [Required(ErrorMessage = "Tamaño Página es requerido")]
        public int? TamanioPagina { get; set; }


        public string LlaveOrdenamiento { get; set; }

        public int Draw { get; set; }

        public string Nombre { get; set; }
       
    }
}
