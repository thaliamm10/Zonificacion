using System;
using System.Collections.Generic;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo
{
    public class Autoridad
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
      //
        public virtual ICollection<NormaInteres> NormaInteres { get; set; }
        public Autoridad()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}