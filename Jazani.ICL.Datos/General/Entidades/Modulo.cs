using System;
using System.Collections.Generic;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo
{
    public class Modulo
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
     //
        public virtual ICollection<NormaInteresModulo> NormaInteresModulo { get; set; }
        public Modulo()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}