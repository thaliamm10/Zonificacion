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
        public TipoProcedimientoDto TipProcedimiento { get; set; }
        public AreaDto Area { get; set; }
        public String IdUsuarioResponsable { get; set; }
        public List<ActividadDto> Actividades { get; set; }
        public List<String> productos { get; set; }

    }
}
