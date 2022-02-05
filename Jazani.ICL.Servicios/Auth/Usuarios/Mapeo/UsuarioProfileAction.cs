using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Servicios.Auth.Perfiles.Dtos;
using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Usuarios.Mapeo
{
    class UsuarioProfileAction : IMappingAction<Usuario, UsuarioDto>
    {
        public void Process(Usuario source, UsuarioDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.Id);
            if (source.Perfil != null)
            {
                destination.Perfil = context.Mapper.Map<PerfilDto>(source.Perfil);
            }
        }
    }
}
