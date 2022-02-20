using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Servicios.General.Modulo.Dtos;

namespace Jazani.ICL.Servicios.General.Modulo.Mapeo
{
    public class ModulosProfileAction: IMappingAction<Modulos,ModulosDto>
    {
        public void Process(Modulos source, ModulosDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.Id);
        }
    }
}