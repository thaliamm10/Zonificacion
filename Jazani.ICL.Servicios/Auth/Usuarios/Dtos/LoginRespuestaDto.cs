﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Usuarios.Dtos
{
    public class LoginRespuestaDto
    {
        public string Nombre { get; set; }
        public string TokenAcceso { get; set; }
    }
}
