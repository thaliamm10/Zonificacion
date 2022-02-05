using Jazani.ICL.Servicios.Auth.Perfiles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Usuarios.Dtos
{
    public class UsuarioDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string EmailAlterno { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public PerfilDto Perfil { get; set; }
    }
}
