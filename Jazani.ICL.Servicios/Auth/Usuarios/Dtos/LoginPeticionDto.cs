using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Usuarios.Dtos
{
    public class LoginPeticionDto
    {
        [Required(ErrorMessage = "Correo es requerido")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Contraseña es requerido")]
        public string Clave { get; set; }
    }
}
