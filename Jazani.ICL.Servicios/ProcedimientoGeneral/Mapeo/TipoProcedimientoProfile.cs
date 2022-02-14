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
    public class TipoProcedimientoProfile : Profile
    {
        public TipoProcedimientoProfile()
        {
            CreateMap<TipoProcedimiento, TipoProcedimientoDto>()
                .AfterMap<TipoProcedimientoProfileAction>();

            CreateMap<TipoProcedimientoDto, TipoProcedimiento>();
        }
    }
}
