using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.General.Entidades
{
    public class Sector
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }

        public Sector()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
