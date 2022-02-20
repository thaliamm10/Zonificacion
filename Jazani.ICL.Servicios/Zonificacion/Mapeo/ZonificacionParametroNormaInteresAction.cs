using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.Zonificacion.Entidades;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;
using Jazani.ICL.Servicios.Zonificacion.Dtos;

namespace Jazani.ICL.Servicios.Zonificacion.Mapeo
{
    public class ZonificacionParametroNormaInteresAction:IMappingAction<ZonificacionParametroNormaInteres,ZonificacionParametroNormaInteresDto>
    {
        public void Process(ZonificacionParametroNormaInteres source, ZonificacionParametroNormaInteresDto destination,
            ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.Id);
          
            if (source.NormaInteres != null)
            {
                destination.NormaInteres = context.Mapper.Map<NormaInteresDto>(source.NormaInteres);
            }
            if (source.ZonificacionParametro != null)
            {
                destination.ZonificacionParametro = context.Mapper.Map<ZonificacionParametroDto>(source.ZonificacionParametro);
            }
        }
    }
}