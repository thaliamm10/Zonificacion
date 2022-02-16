using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Sectores.Dtos
{
    public class SectorDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Codigo es requerido")]
        public string Codigo { get; set; }

        public string Descripcion { get; set; }
    }
}
