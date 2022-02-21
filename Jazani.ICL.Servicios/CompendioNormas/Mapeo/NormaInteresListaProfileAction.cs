using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;
using Jazani.ICL.Servicios.General.Naturaleza.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Mapeo
{
    public class NormaInteresListaProfileAction : IMappingAction<NormaInteres, NormaInteresListaDto>
    {
        public void Process(NormaInteres source, NormaInteresListaDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.Id);
            if (source.Naturaleza != null)
            {
                destination.Naturaleza = context.Mapper.Map<NaturalezaDto>(source.Naturaleza);
            }
        }
    }
}