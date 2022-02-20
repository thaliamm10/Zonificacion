using System;
using Jazani.ICL.Datos.General.Entidades;


namespace Jazani.ICL.Datos.CompendioNormas.Entidades
{
    public class NormaInteresModulo
    {
        public long Id { get; set; }
        public long IdModulo { get; set; }

        public long IdNormaInteres { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }

        public virtual Modulos Modulo { get; set; }
        public virtual NormaInteres NormaInteres { get; set; }
        public NormaInteresModulo()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
