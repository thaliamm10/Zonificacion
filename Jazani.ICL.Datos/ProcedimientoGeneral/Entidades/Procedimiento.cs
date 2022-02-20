using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.ProcedimientoGeneral.Entidades
{
    public class Procedimiento
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        public int IdTipoProcedimiento { get; set; }
        public virtual TipoProcedimiento TipoProcedimiento { get; set; }
        public Procedimiento() {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }

    }
}
