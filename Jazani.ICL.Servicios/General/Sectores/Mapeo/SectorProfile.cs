using AutoMapper;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Servicios.General.Sectores.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Sectores.Mapeo
{
    public class SectorProfile : Profile
    {
        public SectorProfile()
        {
            CreateMap<Sector, SectorDto>()
                .AfterMap<SectorProfileAction>();
        }
    }
}
