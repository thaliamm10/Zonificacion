using AutoMapper;
using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Servicios.Auth.Perfiles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Perfiles.Mapeo
{
    public class PerfilProfile:Profile
    {
        public PerfilProfile()
        {
            CreateMap<Perfil, PerfilDto>()
                .AfterMap<PerfilProfileAction>();

            CreateMap<PerfilDto, Perfil>();
        }
    }
}
