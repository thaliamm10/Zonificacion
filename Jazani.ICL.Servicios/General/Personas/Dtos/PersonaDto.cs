using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Personas.Dtos
{
    public class PersonaDto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Correo { get; set; }
        public DocumentoIdentidadDto DocumentoIdentidad { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public AreaDto Area { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
