using AutoMapper;
using Jazani.ICL.Datos.Zonificacion.Entidades;
using Jazani.ICL.Servicios.Zonificacion.Dtos;

namespace Jazani.ICL.Servicios.Zonificacion.Mapeo
{
    public class ZonificacionParametroProfile:Profile
    {
        public ZonificacionParametroProfile()
        {
            CreateMap<ZonificacionParametro, ZonificacionParametroDto>()
                .AfterMap<ZonificacionParametroAction>();
        }
    }
}