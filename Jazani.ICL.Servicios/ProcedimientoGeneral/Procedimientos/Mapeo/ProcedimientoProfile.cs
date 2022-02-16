using AutoMapper;
using Jazani.ICL.Datos.ProcedimientoGeneral.Entidades;
using Jazani.ICL.Servicios.ProcedimientoGeneral.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.ProcedimientoGeneral.Procedimientos.Mapeo
{
    public class ProcedimientoProfile : Profile
    {
        public ProcedimientoProfile()
        {
            CreateMap<Procedimiento, ProcedimientoDto>()
                .AfterMap<ProcedimientoProfileAction>();

            CreateMap<ProcedimientoDto, Procedimiento>();
        }
    }
}
