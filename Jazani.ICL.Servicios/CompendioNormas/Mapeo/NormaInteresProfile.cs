using AutoMapper;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Mapeo
{
    public class NormaInteresProfile: Profile
    {
        public NormaInteresProfile()
        {
            CreateMap<NormaInteres, NormaInteresDto>()
                .AfterMap<NormaInteresProfileAction>();
        }
    }
}