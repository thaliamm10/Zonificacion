using AutoMapper;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Servicios.General.Tipo_Norma.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Tipo_Norma.Mapeo
{
    public class TipoNormaProfile : Profile
    {
        public TipoNormaProfile()
        {
            CreateMap<Datos.General.Entidades.Tipo_Norma, TipoNormaDto>()
                .AfterMap<TipoNormaProfileAction>();
        }
    }
}
