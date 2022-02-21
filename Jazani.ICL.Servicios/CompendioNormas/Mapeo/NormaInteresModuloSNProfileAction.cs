using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Mapeo
{
    public class NormaInteresModuloSNProfileAction: IMappingAction<NormaInteresModulo, NormaInteresModuloSNDto>
    {
        public void Process(NormaInteresModulo source, NormaInteresModuloSNDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.Id);
        }
    }
}