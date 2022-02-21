using AutoMapper;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Mapeo
{
    public class NormaInteresModuloSNProfile: Profile
    {
        public NormaInteresModuloSNProfile()
        {
            CreateMap<NormaInteresModulo, NormaInteresModuloSNDto>()
                .AfterMap<NormaInteresModuloSNProfileAction>();
        }
    }
}