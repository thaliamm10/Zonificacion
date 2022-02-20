using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.ProcedimientoGeneral.Entidades
{
    public class TipoProcedimiento
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        public virtual ICollection<Procedimiento> Procedimiento { get; set; }

        public TipoProcedimiento()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
