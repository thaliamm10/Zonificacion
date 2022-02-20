using AutoMapper;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Mapeo
{
    public class NormaInteresModuloProfile: Profile
    {
        public NormaInteresModuloProfile()
        {
            CreateMap<NormaInteresModulo, NormaInteresModuloDto>()
                .AfterMap<NormaInteresModuloProfileAction>();
        }
    }
}