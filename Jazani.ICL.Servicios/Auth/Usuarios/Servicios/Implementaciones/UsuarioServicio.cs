using AutoMapper;
using Jazani.Comunes.Seguridad.Servicios.General.Dtos;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.Auth.Entidades;
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
    public class UsuarioServicio: IUsuarioServicio
    {
        private readonly IMapper _mapper;
        private readonly SeguridadConfiguracionDto _seguridadConfiguracion;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioServicio(
                               IMapper mapper,
                               SeguridadConfiguracionDto seguridadConfiguracion,
                               IUsuarioRepositorio usuarioRepositorio
                               )
        {
            _mapper = mapper;
            _seguridadConfiguracion = seguridadConfiguracion;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<OperacionDto<RespuestaSimpleDto<string>>> CrearAsync(UsuarioDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<RespuestaSimpleDto<string>>(peticion);

            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var usuario = _mapper.Map<Usuario>(peticion);

            var idPerfil = RijndaelUtilitario.DecryptRijndaelFromUrl<long>(peticion.Perfil.Id);
            usuario.IdPerfil = idPerfil;
            usuario.Clave = Md5Utilitario.Cifrar(peticion.Clave, _seguridadConfiguracion.PasswordSalt);

            _usuarioRepositorio.Insertar(usuario);
            await _usuarioRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Id = RijndaelUtilitario.EncryptRijndaelToUrl(usuario.Id),
                    Mensaje = "Se creó el usuario correctamente"
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
