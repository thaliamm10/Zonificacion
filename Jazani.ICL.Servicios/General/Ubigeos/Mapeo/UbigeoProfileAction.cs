using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Servicios.General.Ubigeo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Ubigeos.Mapeo
{
    class UbigeoProfileAction : IMappingAction<Datos.General.Entidades.Ubigeo,UbigeoDto>
    {
        public void Process(Datos.General.Entidades.Ubigeo source, UbigeoDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.CodigoUbigeo);
            
        }
    }
}
