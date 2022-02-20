using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Servicios.General.Naturaleza.Dtos;

namespace Jazani.ICL.Servicios.General.Naturaleza.Mapeo
{
    public class NaturalezaProfileAction: IMappingAction<Naturalezas,NaturalezaDto>
    {
        public void Process(Naturalezas source, NaturalezaDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.Id);
        }
    }
}