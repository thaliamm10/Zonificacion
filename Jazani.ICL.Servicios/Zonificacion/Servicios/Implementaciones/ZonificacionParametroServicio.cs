using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.Zonificacion.Dtos;
using Jazani.ICL.Servicios.Zonificacion.Servicios.Abstracciones;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.Zonificacion.Entidades;
using Jazani.ICL.Datos.Zonificacion.Repositorios.Abstracciones;

namespace Jazani.ICL.Servicios.Zonificacion.Servicios.Implementaciones
{
    public class ZonificacionParametroServicio : IZonificacionParametroServicio
    {
        private readonly IMapper _mapper;
        private readonly IZonificacionParametroRepositorio _zonificacionParametroRepositorio;
        public ZonificacionParametroServicio(
            IMapper mapper,
            IZonificacionParametroRepositorio zonificacionParametroRepositorio
        )
        {
            _mapper = mapper;
            _zonificacionParametroRepositorio = zonificacionParametroRepositorio;
        }

        public async Task<OperacionDto<RespuestaSimpleDto<string>>> CrearOActualizarAsync(ZonificacionParametroDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<RespuestaSimpleDto<string>>(peticion);

            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<int>(peticion.Id);

            var entidad = await _zonificacionParametroRepositorio.BuscarPorIdAsync(id);

            if (entidad == null)
            {
                entidad = new ZonificacionParametro();
            }

            entidad.Codigo = peticion.Codigo;
            entidad.Zonificacion = peticion.Zonificacion;
            entidad.Abreviatura = peticion.Abreviatura;
            entidad.CodigoUbigeo = peticion.CodigoUbigeo;
            entidad.IdTipoNorma = peticion.IdTipoNorma;
            entidad.NumeroNormativa = peticion.NumeroNormativa;
            entidad.IdSector = peticion.IdSector;
            entidad.DensidadNeta = peticion.DensidadNeta;
            entidad.FrenteLoteMinNormativo = peticion.FrenteLoteMinNormativo;
            entidad.AlturaMaxEdificacionPiso = peticion.AlturaMaxEdificacionPiso;
            entidad.AlturaMaxEdificacion = peticion.AlturaMaxEdificacion;
            entidad.PorcentajeMinAreaLibre = peticion.PorcentajeMinAreaLibre;
            entidad.UsoPermitido = peticion.UsoPermitido;
            entidad.RequiereEstacionamiento = peticion.RequiereEstacionamiento;
            entidad.CoeficienteEdificacion = peticion.CoeficienteEdificacion;
            entidad.UsoCompatibles = peticion.UsoCompatibles;
            entidad.Nota = peticion.Nota;
            entidad.Observacion = peticion.Observacion;
            entidad.EstadoCulminado = peticion.EstadoCulminado;


            if (entidad.Id == 0)
            {
                var validarZonificacion = await _zonificacionParametroRepositorio.BuscarPorZonificacionAsync(peticion.Zonificacion);
                if (validarZonificacion != null)
                {
                    if (validarZonificacion.Estado == 0)
                    {
                        validarZonificacion.Estado = 1;
                        _zonificacionParametroRepositorio.Editar(validarZonificacion);
                    }
                    else
                    {
                        return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "La zonificación ingresada ya existe");
                    }
                }
                else
                {
                    _zonificacionParametroRepositorio.Insertar(entidad);
                }
            }
            else
            {
                _zonificacionParametroRepositorio.Editar(entidad);
            }
            await _zonificacionParametroRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

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
            var entidad = await _zonificacionParametroRepositorio.BuscarPorIdYNoBorradoAsync(id);
            if (entidad == null)
            {
                return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.NoExiste, "Zonificacion no existe");
            }
            entidad.Estado = 0;
            _zonificacionParametroRepositorio.Editar(entidad);

            await _zonificacionParametroRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Mensaje = "Eliminado correctamente"
                });
        }

        public async Task<OperacionDto<List<ZonificacionParametroDto>>> ListarAsync()
        {

            var zonificacion = await _zonificacionParametroRepositorio.ListarAsync();

            var dto = _mapper.Map<List<ZonificacionParametroDto>>(zonificacion);
            return new OperacionDto<List<ZonificacionParametroDto>>(dto);
        }

        public async Task<OperacionDto<JQueryDatatableDto<ZonificacionParametroDto>>> ListarPaginado(ZonificacionParamtroPaginadoDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<JQueryDatatableDto<ZonificacionParametroDto>>(peticion);
            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var resultados = await _zonificacionParametroRepositorio.ListarPaginadoAsync(peticion.LlaveOrdenamiento,
                peticion.Pagina.Value,
                peticion.TamanioPagina.Value,
                peticion.Zonificacion
            );
            var dto = new JQueryDatatableDto<ZonificacionParametroDto>()
            {
                Data = resultados.Item1.Select(e => _mapper.Map<ZonificacionParametroDto>(e)).ToList(),
                RecordsTotal = resultados.Item2,
                Draw = peticion.Draw,
                RecordsFiltered = resultados.Item2
            };

            return new OperacionDto<JQueryDatatableDto<ZonificacionParametroDto>>(dto);
        }

        public async Task<OperacionDto<ZonificacionParametroDto>> ObtenerAsync(string idZonificacionParametroCifrado)
        {
            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<long>(idZonificacionParametroCifrado);
            var entidad = await _zonificacionParametroRepositorio.BuscarPorIdAsync(id);
            if (entidad == null)
            {
                return new OperacionDto<ZonificacionParametroDto>(CodigosOperacionDto.NoExiste, "Zonificación no existe");
            }

            var dto = _mapper.Map<ZonificacionParametroDto>(entidad);
            return new OperacionDto<ZonificacionParametroDto>(dto);
        }
    }
}