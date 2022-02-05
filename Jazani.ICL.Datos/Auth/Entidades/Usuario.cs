﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Auth.Entidades
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string EmailAlterno { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public long  IdPerfil { get; set; }
        public DateTime  FechaRegistro { get; set; }
        public int  Estado { get; set; }
        public virtual Perfil Perfil { get; set; }
        public Usuario()
        {
            Estado = 1;
        }
    }
}
