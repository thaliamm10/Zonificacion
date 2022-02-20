using System;
using System.Collections.Generic;

namespace Jazani.ICL.Datos.CompendioNormas.Entidades.Mapeo
{
    public class Naturaleza
    {
        //ID_NATURALEZA, CODIGO, DESCRIPCION, FECHA_REGISTRO,
        //
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        public virtual ICollection<NormaInteres> NormaInteres { get; set; }
        public Naturaleza()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}