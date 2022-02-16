using Jazani.ICL.Servicios.General.Personas.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.ProcedimientoGeneral.Dtos
{
    public class ProcedimientoDto
    {
        public String Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        public TipoProcedimientoDto TipoProcedimiento { get; set; }
        public List<ActividadDto> Actividades { get; set; }
        

    }
}
