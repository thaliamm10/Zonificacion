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
    class TipoProcedimientoServicio : ITipoProcedimientoServicio
    {
        private readonly IMapper _mapper;
        private readonly ITipoProcedimientoRepositorio _tipoProcedimientoRepositorio;
        public TipoProcedimientoServicio(
                              IMapper mapper,
                              ITipoProcedimientoRepositorio tipoProcedimientoRepositorio
                             )
        {
            _mapper = mapper;
            _tipoProcedimientoRepositorio = tipoProcedimientoRepositorio;
        }

        public async Task<OperacionDto<RespuestaSimpleDto<string>>> CrearOActualizarAsync(TipoProcedimientoDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<RespuestaSimpleDto<string>>(peticion);

            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<int>(peticion.Id);

            var entidad = await _tipoProcedimientoRepositorio.BuscarPorIdAsync(id);

            if (entidad == null)
            {
                entidad = new TipoProcedimiento();
            }

            entidad.Nombre = peticion.Nombre;

            if (entidad.Id == 0)
            {
                var validarNombre = await _tipoProcedimientoRepositorio.BuscarPorNombreAsync(peticion.Nombre);
                if (validarNombre != null)
                {
                    if (validarNombre.Estado == 0)
                    {
                        validarNombre.Estado = 1;
                        _tipoProcedimientoRepositorio.Editar(validarNombre);
                    }
                    else
                    {
                        return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "El nombre ingresado ya existe");
                    }
                }
                else
                {
                    _tipoProcedimientoRepositorio.Insertar(entidad);
                }
            }
            else
            {
                _tipoProcedimientoRepositorio.Editar(entidad);
            }
            await _tipoProcedimientoRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Id = RijndaelUtilitario.EncryptRijndaelToUrl(entidad.Id),
                    Mensaje = "Se guardó con éxito."
                });
        }

        public async Task<OperacionDto<RespuestaSimpleDto<string>>> EliminarAsync(string idCifrado)
        {
            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<int>(idCifrado);
            var entidad = await _tipoProcedimientoRepositorio.BuscarPorIdYNoBorradoAsync(id);
            if (entidad == null)
            {
                return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.NoExiste, "Tipo procedimiento no existe");
            }
            entidad.Estado = 0;
            _tipoProcedimientoRepositorio.Editar(entidad);

            await _tipoProcedimientoRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Mensaje = "Eliminado correctamente"
                });
        }

        public async Task<OperacionDto<List<TipoProcedimientoDto>>> ListarAsync()
        {
            var json_data = await _tipoProcedimientoRepositorio.ListarAsync();

            var dto = _mapper.Map<List<TipoProcedimientoDto>>(json_data);
            return new OperacionDto<List<TipoProcedimientoDto>>(dto);
        }

        public async Task<OperacionDto<TipoProcedimientoDto>> ObtenerAsync(string idCifrado)
        {
            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<int>(idCifrado);
            var entidad = await _tipoProcedimientoRepositorio.BuscarPorIdAsync(id);
            if (entidad == null)
            {
                return new OperacionDto<TipoProcedimientoDto>(CodigosOperacionDto.NoExiste, "Tipo procedmiento no existe");
            }

            var dto = _mapper.Map<TipoProcedimientoDto>(entidad);
            return new OperacionDto<TipoProcedimientoDto>(dto);
        }
    }
}
