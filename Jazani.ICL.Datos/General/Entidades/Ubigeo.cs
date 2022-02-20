using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jazani.ICL.Datos.Zonificacion.Entidades;

namespace Jazani.ICL.Datos.General.Entidades
{
    public class Ubigeo
    {
        public string CodigoUbigeo { get; set; }
        public string CodigoPadre { get; set; }
        public string CodigoParcial { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        public virtual ICollection<ZonificacionParametro> ZonificacionParametro { get; set; }
        public Ubigeo()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;

        }
    }
}
