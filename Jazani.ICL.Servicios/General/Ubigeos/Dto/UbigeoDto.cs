using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Ubigeo.Dto
{
    public class UbigeoDto
    {
        public string Id { get; set; }
        public string CodigoPadre { get; set; }
        public string CodigoParcial { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public string NombreCompleto { get; set; }
    }
}
