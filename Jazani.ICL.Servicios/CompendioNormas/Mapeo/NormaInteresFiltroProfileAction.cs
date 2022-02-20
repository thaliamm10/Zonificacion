using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.CompendioNormas.Entidades;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;
using Jazani.ICL.Servicios.General.Modulo.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Mapeo
{
    public class NormaInteresFiltroProfileAction: IMappingAction<NormaInteres,NormaInteresFiltroDto> {
        public void Process(NormaInteres source, NormaInteresFiltroDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.Id);

            if (source.NormaInteresModulo != null)
            {
                destination.Modulo = context.Mapper.Map<List<ModulosDto>>(source.NormaInteresModulo
                    .Select(e => e.Modulo).ToList());
            }

        }
    }
}