using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Datos.Auth.Repositorios.Abstracciones;
using Jazani.ICL.Servicios.Auth.Perfiles.Dtos;
using Jazani.ICL.Servicios.Auth.Perfiles.Servicios.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Perfiles.Servicios.Implementaciones
{
    public class PerfilServicio: IPerfilServicio
    {
        private readonly IMapper _mapper;
        private readonly IPerfilRepositorio _perfilRepositorio;
        public PerfilServicio(
                              IMapper mapper,
                              IPerfilRepositorio perfilRepositorio
                             )
        {
            _mapper = mapper;
            _perfilRepositorio = perfilRepositorio;
        }

        public async Task<OperacionDto<RespuestaSimpleDto<string>>> CrearAsync(PerfilDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<RespuestaSimpleDto<string>>(peticion);

            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var perfil = _mapper.Map<Perfil>(peticion);
           
            _perfilRepositorio.Insertar(perfil);
            await _perfilRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Id = RijndaelUtilitario.EncryptRijndaelToUrl(perfil.Id),
                    Mensaje = "Se creó correctamente"
                });

        }

        public async Task<OperacionDto<List<PerfilDto>>> ListarAsync()
        {
            var usuarios = await _perfilRepositorio.ListarAsync();

            var dto = _mapper.Map<List<PerfilDto>>(usuarios);
            return new OperacionDto<List<PerfilDto>>(dto);
        }
    }
}
