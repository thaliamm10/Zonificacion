using AutoMapper;
using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Usuarios.Mapeo
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>()
                .AfterMap<UsuarioProfileAction>();
        }
    }
}
