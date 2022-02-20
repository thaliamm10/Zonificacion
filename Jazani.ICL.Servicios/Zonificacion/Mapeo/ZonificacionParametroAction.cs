using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.Zonificacion.Entidades;
using Jazani.ICL.Servicios.General.Sectores.Dtos;
using Jazani.ICL.Servicios.General.Tipo_Norma.Dtos;
using Jazani.ICL.Servicios.General.Ubigeo.Dto;
using Jazani.ICL.Servicios.Zonificacion.Dtos;

namespace Jazani.ICL.Servicios.Zonificacion.Mapeo
{
    public class ZonificacionParametroAction : IMappingAction<ZonificacionParametro, ZonificacionParametroDto>
    {
        public void Process(ZonificacionParametro source, ZonificacionParametroDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.Id);
            if (source.TipoNormativa != null)
            {
                destination.TipoNorma = context.Mapper.Map<TipoNormaDto>(source.TipoNormativa);
            }
            if (source.Ubigeo != null)
            {
                destination.Ubigeo = context.Mapper.Map<UbigeoDto>(source.Ubigeo);
            }
            if (source.Sector != null)
            {
                destination.Sector = context.Mapper.Map<SectorDto>(source.Sector);
            }
        }
    }
}