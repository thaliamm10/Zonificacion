using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.ProcedimientoGeneral.Entidades;
using Jazani.ICL.Datos.ProcedimientoGeneral.Repositorios.Abstracciones;
using Jazani.ICL.Servicios.ProcedimientoGeneral.Dtos;
using Jazani.ICL.Servicios.ProcedimientoGeneral.Servicios.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.ProcedimientoGeneral.Servicios.Implementaciones
{
    class TipoActividadServicio : ITipoActividadServicio
    {
        private readonly IMapper _mapper;
        private readonly ITipoActividadRepositorio _tipoActividadRepositorio;
        public TipoActividadServicio(
                              IMapper mapper,
                              ITipoActividadRepositorio tipoActividadRepositorio
                             )
        {
            _mapper = mapper;
            _tipoActividadRepositorio = tipoActividadRepositorio;
        }

        public async Task<OperacionDto<RespuestaSimpleDto<string>>> CrearOActualizarAsync(TipoActividadDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<RespuestaSimpleDto<string>>(peticion);

            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<int>(peticion.Id);

            var entidad = await _tipoActividadRepositorio.BuscarPorIdAsync(id);

            if (entidad == null)
            {
                entidad = new TipoActividad();
            }

            entidad.Nombre = peticion.Nombre;

            if (entidad.Id == 0)
            {
                var validarNombre = await _tipoActividadRepositorio.BuscarPorNombreAsync(peticion.Nombre);
                if (validarNombre != null)
                {
                    if (validarNombre.Estado == 0)
                    {
                        validarNombre.Estado = 1;
                        _tipoActividadRepositorio.Editar(validarNombre);
                    }
                    else
                    {
                        return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "El nombre ingresado ya existe");
                    }
                }
                else
                {
                    _tipoActividadRepositorio.Insertar(entidad);
                }
            }
            else
            {
                _tipoActividadRepositorio.Editar(entidad);
            }
            await _tipoActividadRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Id = RijndaelUtilitario.EncryptRijndaelToUrl(entidad.Id),
                    Mensaje = "Se guardó con éxito."
                });
        }

        public async Task<OperacionDto<RespuestaSimpleDto<string>>> EliminarAsync(string idTipoActividadCifrado)
        {
            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<int>(idTipoActividadCifrado);
            var entidad = await _tipoActividadRepositorio.BuscarPorIdYNoBorradoAsync(id);
            if (entidad == null)
            {
                return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.NoExiste, "Tipo de actividad no existe");
            }
            entidad.Estado = 0;
            _tipoActividadRepositorio.Editar(entidad);

            await _tipoActividadRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Mensaje = "Eliminado correctamente"
                });
        }

        public async Task<OperacionDto<List<TipoActividadDto>>> ListarAsync()
        {
            var json_data = await _tipoActividadRepositorio.ListarAsync();

            var dto = _mapper.Map<List<TipoActividadDto>>(json_data);
            return new OperacionDto<List<TipoActividadDto>>(dto);
        }

        public async Task<OperacionDto<TipoActividadDto>> ObtenerAsync(string idTipoActividadCifrado)
        {
            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<int>(idTipoActividadCifrado);
            var entidad = await _tipoActividadRepositorio.BuscarPorIdAsync(id);
            if (entidad == null)
            {
                return new OperacionDto<TipoActividadDto>(CodigosOperacionDto.NoExiste, "Tipo actividad no existe");
            }

            var dto = _mapper.Map<TipoActividadDto>(entidad);
            return new OperacionDto<TipoActividadDto>(dto);
        }
    }
}
