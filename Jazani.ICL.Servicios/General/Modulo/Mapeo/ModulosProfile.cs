using AutoMapper;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Servicios.General.Modulo.Dtos;
namespace Jazani.ICL.Servicios.General.Modulo.Mapeo
{
    public class ModulosProfile:Profile
    {
        public ModulosProfile()
        {
            CreateMap<Modulos, ModulosDto>()
                .AfterMap<ModulosProfileAction>();
        }
    }
}