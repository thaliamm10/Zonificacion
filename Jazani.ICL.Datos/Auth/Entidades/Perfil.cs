using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Auth.Entidades
{
    public class Perfil
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }

        public Perfil()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
