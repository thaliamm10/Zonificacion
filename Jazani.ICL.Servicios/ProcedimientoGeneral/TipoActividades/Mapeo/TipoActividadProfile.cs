using AutoMapper;
using Jazani.ICL.Datos.ProcedimientoGeneral.Entidades;
using Jazani.ICL.Servicios.ProcedimientoGeneral.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.ProcedimientoGeneral.Mapeo
{
    public class TipoActividadProfile : Profile
    {
        public TipoActividadProfile ()
        {
            CreateMap<TipoActividad, TipoActividadDto>()
                .AfterMap<TipoActividadProfileAction>();

            CreateMap<TipoActividadDto, TipoActividad>();
        }
    }
}
