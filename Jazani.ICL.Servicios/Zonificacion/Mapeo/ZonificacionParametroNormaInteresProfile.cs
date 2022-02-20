using AutoMapper;
using Jazani.ICL.Datos.Zonificacion.Entidades;
using Jazani.ICL.Servicios.Zonificacion.Dtos;

namespace Jazani.ICL.Servicios.Zonificacion.Mapeo
{
    public class ZonificacionParametroNormaInteresProfile:Profile
    {
        public ZonificacionParametroNormaInteresProfile()
        {
            CreateMap<ZonificacionParametroNormaInteres, ZonificacionParametroNormaInteresDto>()
                .AfterMap<ZonificacionParametroNormaInteresAction>();
        }
    }
}