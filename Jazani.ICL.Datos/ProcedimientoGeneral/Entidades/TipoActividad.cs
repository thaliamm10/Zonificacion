using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.ProcedimientoGeneral.Entidades
{
    public class TipoActividad
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        public TipoActividad()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
