using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Servicios.Auth.Perfiles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Perfiles.Mapeo
{
    class PerfilProfileAction : IMappingAction<Perfil, PerfilDto>
    {
        public void Process(Perfil source, PerfilDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.Id);
        }
    }
}
