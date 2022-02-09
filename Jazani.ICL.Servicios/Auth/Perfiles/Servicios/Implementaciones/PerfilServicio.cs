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

        public async Task<OperacionDto<RespuestaSimpleDto<string>>> CrearOActualizarAsync(PerfilDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<RespuestaSimpleDto<string>>(peticion);

            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<int>(peticion.Id);

            var entidad = await _perfilRepositorio.BuscarPorIdAsync(id);

            if (entidad == null)
            {
                entidad = new Perfil();
            }

            entidad.Nombre = peticion.Nombre;
            entidad.Descripcion = peticion.Descripcion;

            if (entidad.Id == 0)
            {
                var validarNombre = await _perfilRepositorio.BuscarPorNombreAsync(peticion.Nombre);
                if (validarNombre != null)
                {
                    if (validarNombre.Estado == 0)
                    {
                        validarNombre.Estado = 1;
                        _perfilRepositorio.Editar(validarNombre);
                    }
                    else
                    {
                        return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "El nombre ingresado ya existe");
                    }
                }
                else
                {
                    _perfilRepositorio.Insertar(entidad);
                }
            }
            else
            {
                _perfilRepositorio.Editar(entidad);
            }
            await _perfilRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Id = RijndaelUtilitario.EncryptRijndaelToUrl(entidad.Id),
                    Mensaje = "Se guardó con éxito."
                });

        }

        public async Task<OperacionDto<RespuestaSimpleDto<string>>> EliminarAsync(string idPerfilCifrado)
        {
            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<long>(idPerfilCifrado);
            var entidad = await _perfilRepositorio.BuscarPorIdYNoBorradoAsync(id);
            if (entidad == null)
            {
                return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.NoExiste, "Perfil no existe");
            }
            entidad.Estado = 0;
            _perfilRepositorio.Editar(entidad);

            await _perfilRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Mensaje = "Eliminado correctamente"
                });
        }

        public async Task<OperacionDto<PerfilDto>> ObtenerAsync(string idPerfilCifrado)
        {
            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<long>(idPerfilCifrado);
            var entidad = await _perfilRepositorio.BuscarPorIdAsync(id);
            if (entidad == null)
            {
                return new OperacionDto<PerfilDto>(CodigosOperacionDto.NoExiste, "Perfil no existe");
            }

            var dto = _mapper.Map<PerfilDto>(entidad);
            return new OperacionDto<PerfilDto>(dto);
        }

        public async Task<OperacionDto<List<PerfilDto>>> ListarAsync()
        {
            var usuarios = await _perfilRepositorio.ListarAsync();

            var dto = _mapper.Map<List<PerfilDto>>(usuarios);
            return new OperacionDto<List<PerfilDto>>(dto);
        }

        public async Task<OperacionDto<JQueryDatatableDto<PerfilDto>>> ListarPaginado(PerfilPaginadoPeticionDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<JQueryDatatableDto<PerfilDto>>(peticion);
            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var resultados = await _perfilRepositorio.ListarPaginadoAsync(peticion.LlaveOrdenamiento,
                                                                                              peticion.Pagina.Value,
                                                                                              peticion.TamanioPagina.Value,
                                                                                              peticion.Nombre
                                                                                              );
            var dto = new JQueryDatatableDto<PerfilDto>()
            {
                Data = resultados.Item1.Select(e => _mapper.Map<PerfilDto>(e)).ToList(),
                RecordsTotal = resultados.Item2,
                Draw = peticion.Draw,
                RecordsFiltered = resultados.Item2
            };

            return new OperacionDto<JQueryDatatableDto<PerfilDto>>(dto);
        }

    }
}
