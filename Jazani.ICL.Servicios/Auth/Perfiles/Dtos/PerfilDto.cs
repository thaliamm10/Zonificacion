using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Perfiles.Dtos
{
    public class PerfilDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
