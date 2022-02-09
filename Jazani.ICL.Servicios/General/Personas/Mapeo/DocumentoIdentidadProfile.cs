using AutoMapper;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Servicios.General.Personas.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Personas.Mapeo
{
    public class DocumentoIdentidadProfile : Profile
    {
        public DocumentoIdentidadProfile()
        {
            CreateMap<DocumentoIdentidad, DocumentoIdentidadDto>()
                .AfterMap<DocumentoIdentidadProfileAction>();
        }
    }
}
