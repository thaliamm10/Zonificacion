using AutoMapper;
using Jazani.Comunes.Seguridad.Servicios.Auth.Servicios.Abstracciones;
using Jazani.Comunes.Seguridad.Servicios.General.Dtos;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.Auth.Repositorios.Abstracciones;
using Jazani.ICL.Datos.General.Repositorio.Abstracciones;
using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using Jazani.ICL.Servicios.Auth.Usuarios.Servicios.Abstracciones;
using Jazani.ICL.Servicios.General.Personas.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Usuarios.Servicios.Implementaciones
{
    public class LoginServicio: ILoginServicio
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly SeguridadConfiguracionDto _seguridadConfiguracion;
        private readonly ITokenAccesoServicio _tokenAccesoServicio;
        private readonly IPersonaRepositorio _personaRepositorio;

        public LoginServicio(
                                    IMapper mapper,
                                    IUsuarioRepositorio usuarioRepositorio,
                                    SeguridadConfiguracionDto seguridadConfiguracion,
                                    ITokenAccesoServicio tokenAccesoServicio,
                                    IPersonaRepositorio personaRepositorio)
        {
            _mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
            _seguridadConfiguracion = seguridadConfiguracion;
            _tokenAccesoServicio = tokenAccesoServicio;
            _personaRepositorio = personaRepositorio;
        }

        public async Task<OperacionDto<LoginRespuestaDto>> LoginAsync(LoginPeticionDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<LoginRespuestaDto>(peticion);
            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }
            var persona = await _personaRepositorio.BuscarPorUsuarioAsync(peticion.Usuario);
            if (persona == null)
            {
                return new OperacionDto<LoginRespuestaDto>(CodigosOperacionDto.UsuarioIncorrecto, "Usuario o Contraseña inválida");
            }

            if (persona.Usuario.Estado != 1)
            {
                return new OperacionDto<LoginRespuestaDto>(CodigosOperacionDto.UsuarioInhabilitado, "Usuario no habilitado");
            }

            if (Md5Utilitario.Cifrar(peticion.Clave, persona.Usuario.ClaveSalt) != persona.Usuario.Clave)
            {
                return new OperacionDto<LoginRespuestaDto>(CodigosOperacionDto.UsuarioIncorrecto, "Usuario o Contraseña inválida");
            }

            await _personaRepositorio.UnidadDeTrabajo.Entry(persona).Reference(e => e.Usuario).Query().Include(e => e.Perfil).LoadAsync(); 
            await _personaRepositorio.UnidadDeTrabajo.Entry(persona).Reference(e => e.DocumentoIdentidad).LoadAsync(); 
            await _personaRepositorio.UnidadDeTrabajo.Entry(persona).Reference(e => e.Area).LoadAsync(); 

            return new OperacionDto<LoginRespuestaDto>(new LoginRespuestaDto()
            {
                Persona = _mapper.Map<PersonaDto>(persona),
                TokenAcceso = _tokenAccesoServicio.GenerarTokenRSA(persona.Usuario.Id)
            });
        }
    }
}
