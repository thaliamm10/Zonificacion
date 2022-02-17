using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.Zonificacion.Entidades;
using Jazani.ICL.Servicios.Zonificacion.Dtos;

namespace Jazani.ICL.Servicios.Zonificacion.Mapeo
{
    public class ZonificacionParametroAction : IMappingAction<ZonificacionParametro, ZonificacionParametroDto>
    {
        public void Process(ZonificacionParametro source, ZonificacionParametroDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.Id);
        }
    }
}