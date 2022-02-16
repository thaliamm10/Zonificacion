using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.ProcedimientoGeneral.Dtos
{
    public class ActividadDto
    {
        public String Id { get; set; }
        public String NumActividad { get; set; }
        public String NumActividadAnterior { get; set; }
        public String NumActividadSiguiente { get; set; }
        public String Descripcion { get; set; }
        public int PlazoAtencion { get; set; }
        public int NotificacionCorreo { get; set; }
        public int Flag { get; set; }
        public TipoActividadDto TipActividad { get; set; }

    }
}
