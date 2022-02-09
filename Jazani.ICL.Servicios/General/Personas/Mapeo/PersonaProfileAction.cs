using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Servicios.Auth.Perfiles.Dtos;
using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using Jazani.ICL.Servicios.General.Personas.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Personas.Mapeo
{
    class PersonaProfileAction : IMappingAction<Persona, PersonaDto>
    {
        public void Process(Persona source, PersonaDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.Id);
            if (source.Usuario != null)
            {
                destination.Usuario.Id= RijndaelUtilitario.EncryptRijndaelToUrl(source.Usuario.Id);
                destination.Usuario.NombreUsuario= source.Usuario.NombreUsuario;
                destination.Usuario.Clave=null;
                if (source.Usuario.Perfil != null)
                {
                    destination.Usuario.Perfil = context.Mapper.Map<PerfilDto>(source.Usuario.Perfil);
                }
            }
            if (source.DocumentoIdentidad != null)
            {
                destination.DocumentoIdentidad = context.Mapper.Map<DocumentoIdentidadDto>(source.DocumentoIdentidad);
            }
            if (source.Area != null)
            {
                destination.Area = context.Mapper.Map<AreaDto>(source.Area);
            }
        }
    }
}
