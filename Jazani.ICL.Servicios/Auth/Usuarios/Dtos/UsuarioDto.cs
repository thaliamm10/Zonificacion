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
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public PerfilDto Perfil { get; set; }
    }
}
