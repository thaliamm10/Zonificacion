using AutoMapper;
using Jazani.ICL.Servicios.General.Ubigeo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jazani.ICL.Datos.General.Entidades;

namespace Jazani.ICL.Servicios.General.Ubigeos.Mapeo
{
    public class UbigeoProfile : Profile
    {
        public UbigeoProfile()
        {
            CreateMap<Datos.General.Entidades.Ubigeo , UbigeoDto>()
                .AfterMap<UbigeoProfileAction>();
            
        }
            
    }
}
