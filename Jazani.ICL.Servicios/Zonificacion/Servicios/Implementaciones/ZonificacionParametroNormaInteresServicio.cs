using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.Zonificacion.Entidades;
using Jazani.ICL.Datos.Zonificacion.Repositorios.Abstracciones;
using Jazani.ICL.Servicios.Zonificacion.Dtos;
using Jazani.ICL.Servicios.Zonificacion.Servicios.Abstracciones;

namespace Jazani.ICL.Servicios.Zonificacion.Servicios.Implementaciones
{
    public class ZonificacionParametroNormaInteresServicio: IZonificacionParametroNormaInteresServicio
    {
        private readonly IMapper _mapper;
        private readonly IZonificacionParametroNormaInteresRepositorio _zonificacionParametroNormaInteresRepositorio;
        public ZonificacionParametroNormaInteresServicio(
            IMapper mapper,
            IZonificacionParametroNormaInteresRepositorio zonificacionParametroNormaInteresRepositorio
        )
        {
            _mapper = mapper;
            _zonificacionParametroNormaInteresRepositorio = zonificacionParametroNormaInteresRepositorio;
        }

        public async Task<OperacionDto<RespuestaSimpleDto<string>>> CrearOActualizarAsync(ZonificacionParametroNormaInteresDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<RespuestaSimpleDto<string>>(peticion);

            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<int>(peticion.Id);

            var entidad = await _zonificacionParametroNormaInteresRepositorio.BuscarPorIdAsync(id);

            if (entidad == null)
            {
                entidad = new ZonificacionParametroNormaInteres();
            }

            entidad.IdNormaInteres = peticion.IdNormaInteres;
            entidad.IdZonificacionParametro = peticion.IdZonificacionParametro;
            entidad.Estado = peticion.Estado;
            

            if (entidad.Id == 0)
            {
                var validarZonificacion = await _zonificacionParametroNormaInteresRepositorio.BuscarPorIdNormaInteresAsync(peticion.IdNormaInteres);
                if (validarZonificacion != null)
                {
                    if (validarZonificacion.Estado == 0)
                    {
                        validarZonificacion.Estado = 1;
                        _zonificacionParametroNormaInteresRepositorio.Editar(validarZonificacion);
                    }
                    else
                    {
                        return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "La zonificación ingresada ya existe");
                    }
                }
                else
                {
                    _zonificacionParametroNormaInteresRepositorio.Insertar(entidad);
                }
            }
            else
            {
                _zonificacionParametroNormaInteresRepositorio.Editar(entidad);
            }
            await _zonificacionParametroNormaInteresRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Id = RijndaelUtilitario.EncryptRijndaelToUrl(entidad.Id),
                    Mensaje = "Se guardó con éxito."
                });
        }

        public async Task<OperacionDto<RespuestaSimpleDto<string>>> EliminarAsync(string idZonificacionParametroCifrado)
        {
            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<long>(idZonificacionParametroCifrado);
            var entidad = await _zonificacionParametroNormaInteresRepositorio.BuscarPorIdYNoBorradoAsync(id);
            if (entidad == null)
            {
                return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.NoExiste, "Relación no existe");
            }
            entidad.Estado = 0;
            _zonificacionParametroNormaInteresRepositorio.Editar(entidad);

            await _zonificacionParametroNormaInteresRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Mensaje = "Eliminado correctamente"
                });
        }

        public async Task<OperacionDto<ZonificacionParametroNormaInteresDto>> ObtenerAsync(string idZonificacionParametroCifrado)
        {

            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<long>(idZonificacionParametroCifrado);
            var entidad = await _zonificacionParametroNormaInteresRepositorio.BuscarPorIdAsync(id);
            if (entidad == null)
            {
                return new OperacionDto<ZonificacionParametroNormaInteresDto>(CodigosOperacionDto.NoExiste, "Zonificación no existe");
            }

            var dto = _mapper.Map<ZonificacionParametroNormaInteresDto>(entidad);
            return new OperacionDto<ZonificacionParametroNormaInteresDto>(dto);
        }

        public async Task<OperacionDto<List<ZonificacionParametroNormaInteresDto>>> ListarAsync()
        {
            var zonificacion = await _zonificacionParametroNormaInteresRepositorio.ListarAsync();

            var dto = _mapper.Map<List<ZonificacionParametroNormaInteresDto>>(zonificacion);
            return new OperacionDto<List<ZonificacionParametroNormaInteresDto>>(dto);
        }

        public async Task<OperacionDto<JQueryDatatableDto<ZonificacionParametroNormaInteresDto>>> ListarPaginado(ZonificacionParamtroPaginadoDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<JQueryDatatableDto<ZonificacionParametroNormaInteresDto>>(peticion);
            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var resultados = await _zonificacionParametroNormaInteresRepositorio.ListarPaginadoAsync(peticion.LlaveOrdenamiento,
                peticion.Pagina.Value,
                peticion.TamanioPagina.Value,
                peticion.Zonificacion
            );
            var dto = new JQueryDatatableDto<ZonificacionParametroNormaInteresDto>()
            {
                Data = resultados.Item1.Select(e => _mapper.Map<ZonificacionParametroNormaInteresDto>(e)).ToList(),
                RecordsTotal = resultados.Item2,
                Draw = peticion.Draw,
                RecordsFiltered = resultados.Item2
            };

            return new OperacionDto<JQueryDatatableDto<ZonificacionParametroNormaInteresDto>>(dto);
        }
    }
}