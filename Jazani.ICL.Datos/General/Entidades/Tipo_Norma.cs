using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.General.Entidades
{
    public class Tipo_Norma
    {
        public long ID_TIPO_NORMA { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }

        public Tipo_Norma()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
