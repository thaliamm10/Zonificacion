using AutoMapper;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Servicios.General.Naturaleza.Dtos;

namespace Jazani.ICL.Servicios.General.Naturaleza.Mapeo
{
    public class NaturalezaProfile:Profile
    {
        public NaturalezaProfile()
        {
            CreateMap<Naturalezas, NaturalezaDto>()
                .AfterMap<NaturalezaProfileAction>();
        }
    }
}