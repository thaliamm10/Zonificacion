using System;
using System.Collections.Generic;
using Jazani.ICL.Datos.CompendioNormas.Entidades;

namespace Jazani.ICL.Datos.General.Entidades
{
    public class Modulos
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        //
        public virtual ICollection<NormaInteresModulo> NormaInteresModulo { get; set; }
        public Modulos()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}