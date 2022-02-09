using Jazani.ICL.Datos.Auth.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.General.Entidades
{
    public class Persona
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Correo { get; set; }
        public int IdDocumentoIdentidad { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int? IdArea { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Area Area { get; set; }
        public virtual DocumentoIdentidad DocumentoIdentidad { get; set; }
        public Persona()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}
