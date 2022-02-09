using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.General.Entidades
{
    public class DocumentoIdentidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }

        public DocumentoIdentidad()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
