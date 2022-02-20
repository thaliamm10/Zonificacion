using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;
using Jazani.ICL.Servicios.General.Modulo.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Mapeo
{
    public class NormaInteresModuloProfileAction: IMappingAction<NormaInteresModulo,NormaInteresModuloDto>
    {
        public void Process(NormaInteresModulo source, NormaInteresModuloDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.Id);

            if (source.NormaInteres != null)
            {
                destination.NormaInteres = context.Mapper.Map<NormaInteresListaDto>(source.NormaInteres);
            }
            if (source.Modulo != null)
            {
                destination.Modulo = context.Mapper.Map<ModulosDto>(source.Modulo);
            }
        }
    }
}