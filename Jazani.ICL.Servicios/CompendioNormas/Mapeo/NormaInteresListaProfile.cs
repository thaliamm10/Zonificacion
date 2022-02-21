using AutoMapper;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Mapeo
{
    public class NormaInteresListaProfile: Profile
    {
        public NormaInteresListaProfile()
        {
            CreateMap<NormaInteres, NormaInteresListaDto>()
                .AfterMap<NormaInteresListaProfileAction>();
        }
    }
}