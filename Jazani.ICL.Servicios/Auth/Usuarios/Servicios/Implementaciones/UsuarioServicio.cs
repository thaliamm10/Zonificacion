using AutoMapper;
using Jazani.Comunes.Seguridad.Servicios.General.Dtos;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Datos.Auth.Repositorios.Abstracciones;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Datos.General.Repositorio.Abstracciones;
using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using Jazani.ICL.Servicios.Auth.Usuarios.Servicios.Abstracciones;
using Jazani.ICL.Servicios.General.Personas.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Usuarios.Servicios.Implementaciones
{
    public class UsuarioServicio: IUsuarioServicio
    {
        private readonly IMapper _mapper;
        private readonly SeguridadConfiguracionDto _seguridadConfiguracion;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IPersonaRepositorio _personaRepositorio;
        public UsuarioServicio(
                               IMapper mapper,
                               SeguridadConfiguracionDto seguridadConfiguracion,
                               IUsuarioRepositorio usuarioRepositorio,
                               IPersonaRepositorio personaRepositorio
                               )
        {
            _mapper = mapper;
            _seguridadConfiguracion = seguridadConfiguracion;
            _usuarioRepositorio = usuarioRepositorio;
            _personaRepositorio = personaRepositorio;
        }

        public async Task<OperacionDto<RespuestaSimpleDto<string>>> CrearAsync(UsuarioDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<RespuestaSimpleDto<string>>(peticion);

            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var usuario = new Usuario();

            var idPerfil = RijndaelUtilitario.DecryptRijndaelFromUrl<long>(peticion.Perfil.Id);
            usuario.Id = 2;
            usuario.NombreUsuario = peticion.NombreUsuario;
            usuario.IdPerfil = idPerfil;
            usuario.Clave = Md5Utilitario.Cifrar(peticion.Clave, _seguridadConfiguracion.PasswordSalt);
            usuario.ClaveSalt = _seguridadConfiguracion.PasswordSalt;

            _usuarioRepositorio.Insertar(usuario);
            await _usuarioRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Id = RijndaelUtilitario.EncryptRijndaelToUrl(usuario.Id),
                    Mensaje = "Se creó el usuario correctamente"
                });

        }

        public async Task<OperacionDto<RespuestaSimpleDto<string>>> CrearPersonaUsuarioAsync(PersonaDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<RespuestaSimpleDto<string>>(peticion);

            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var persona = new Persona();

            persona.Nombre = peticion.Nombre;
            persona.Paterno = peticion.Paterno;
            persona.Materno = peticion.Materno;
            persona.Correo = peticion.Correo;
            persona.IdDocumentoIdentidad = 1;//peticion.DocumentoIdentidad.Id;
            persona.Documento = peticion.Documento;
            persona.Telefono = peticion.Telefono;
            persona.Direccion = peticion.Direccion;
            //persona.IdArea = peticion.Area.Id;
            
            var validarDocumento = await _personaRepositorio.BuscarPorDocumentoAsync(peticion.Documento);
            
            if (validarDocumento != null)
            {
                if (validarDocumento.Estado == 0)
                {
                    validarDocumento.Estado = 1;
                    _personaRepositorio.Editar(validarDocumento);
                }
                else
                {
                    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "El número de documento ingresado ya existe");
                }
            }
            else
            {
                _personaRepositorio.Insertar(persona);
            }

            var validarNombreUsuario = await _usuarioRepositorio.BuscarPorUsuarioAsync(peticion.Usuario.NombreUsuario);

            if (validarNombreUsuario != null)
            {
                if (validarNombreUsuario.Estado != 0)
                {
                    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "El nombre usuario ingresado ya existe");
                }
            }

            await _personaRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            var usuario = new Usuario();

            var idPerfil = RijndaelUtilitario.DecryptRijndaelFromUrl<long>(peticion.Usuario.Perfil.Id);
            usuario.Id = persona.Id;
            usuario.NombreUsuario = peticion.Usuario.NombreUsuario;
            usuario.IdPerfil = idPerfil;
            usuario.Clave = Md5Utilitario.Cifrar(peticion.Usuario.Clave, _seguridadConfiguracion.PasswordSalt);
            usuario.ClaveSalt = _seguridadConfiguracion.PasswordSalt;

            
            if (validarNombreUsuario != null)
            {
                if (validarNombreUsuario.Estado == 0)
                {
                    validarNombreUsuario.Estado = 1;
                    validarNombreUsuario.IdPerfil = usuario.IdPerfil;
                    validarNombreUsuario.Clave = usuario.Clave;
                    validarNombreUsuario.ClaveSalt = usuario.ClaveSalt;
                    _usuarioRepositorio.Editar(validarNombreUsuario);
                }
                else
                {
                    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "El nombre usuario ingresado ya existe");
                }
            }
            else
            {
                _usuarioRepositorio.Insertar(usuario);
            }

           
            await _usuarioRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Id = RijndaelUtilitario.EncryptRijndaelToUrl(persona.Id),
                    Mensaje = "Se guardó correctamente"
                });

        }

        public async Task<OperacionDto<List<UsuarioDto>>> ListarAsync()
        {
            var usuarios = await _usuarioRepositorio.ListarAsync();

            var dto = _mapper.Map<List<UsuarioDto>>(usuarios);
            return new OperacionDto<List<UsuarioDto>>(dto);
        }
    }
}
