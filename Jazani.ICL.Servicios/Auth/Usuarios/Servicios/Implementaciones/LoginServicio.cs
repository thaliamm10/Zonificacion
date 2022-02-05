using AutoMapper;
using Jazani.Comunes.Seguridad.Servicios.Auth.Servicios.Abstracciones;
using Jazani.Comunes.Seguridad.Servicios.General.Dtos;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.Auth.Repositorios.Abstracciones;
using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using Jazani.ICL.Servicios.Auth.Usuarios.Servicios.Abstracciones;
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

        public LoginServicio(
                                    IMapper mapper,
                                    IUsuarioRepositorio usuarioRepositorio,
                                    SeguridadConfiguracionDto seguridadConfiguracion,
                                    ITokenAccesoServicio tokenAccesoServicio)
        {
            _mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
            _seguridadConfiguracion = seguridadConfiguracion;
            _tokenAccesoServicio = tokenAccesoServicio;
        }

        public async Task<OperacionDto<LoginRespuestaDto>> LoginAsync(LoginPeticionDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<LoginRespuestaDto>(peticion);
            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }
            var usuario = await _usuarioRepositorio.BuscarPorUsuarioAsync(peticion.Correo);
            if (usuario == null)
            {
                return new OperacionDto<LoginRespuestaDto>(CodigosOperacionDto.UsuarioIncorrecto, "Usuario o Contraseña inválida");
            }

            if (Convert.ToInt32(usuario.Estado) != 1)
            {
                return new OperacionDto<LoginRespuestaDto>(CodigosOperacionDto.UsuarioInhabilitado, "Usuario no habilitado");
            }

            if (Md5Utilitario.Cifrar(peticion.Clave, _seguridadConfiguracion.PasswordSalt) != usuario.Clave)
            {
                return new OperacionDto<LoginRespuestaDto>(CodigosOperacionDto.UsuarioIncorrecto, "Usuario o Contraseña inválida");
            }

            return new OperacionDto<LoginRespuestaDto>(new LoginRespuestaDto()
            {
                Nombre = usuario.Nombres,
                TokenAcceso = _tokenAccesoServicio.GenerarTokenRSA(usuario.Id)
            });
        }
    }
}
