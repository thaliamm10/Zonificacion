using AutoMapper;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Mapeo
{
    public class NormaInteresFiltroProfile : Profile
    {
        public NormaInteresFiltroProfile()
        {
            CreateMap<NormaInteres, NormaInteresFiltroDto>()
                .AfterMap<NormaInteresFiltroProfileAction>();
        }
    }
}