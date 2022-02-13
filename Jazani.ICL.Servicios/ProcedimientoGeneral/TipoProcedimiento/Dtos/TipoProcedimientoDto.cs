using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.ProcedimientoGeneral.TipoProcedimiento.Dtos
{
    public class TipoProcedimientoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es Requerido")]
        public String Nombre { get; set; }
    }
}
