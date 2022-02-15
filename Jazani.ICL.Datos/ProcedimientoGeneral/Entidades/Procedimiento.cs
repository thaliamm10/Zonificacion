using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.ProcedimientoGeneral.Entidades
{
    public class Procedimiento
    {
        public int IdProcedimiento { get; set; }
        public String NombreProcedimiento { get; set; }
        public String DescripcionProcedimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        public int IdTipoProc { get; set; }
        public String NombreTipoProc { get; set; }

    }
}
