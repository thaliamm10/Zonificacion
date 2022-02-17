using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Datos.General.Repositorio.Abstracciones;
using Jazani.ICL.Servicios.General.Tipo_Norma.Dtos;
using Jazani.ICL.Servicios.General.Tipo_Norma.Servicios.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Tipo_Norma.Servicios.Implementaciones
{
    public class TipoNormaServicio : ITipoNorma
    {
        private readonly IMapper _mapper;
        private readonly ITipoNormaRepositorio _tipoNormaRepositorio;
        public TipoNormaServicio(
                              IMapper mapper,
                              ITipoNormaRepositorio tipoNormaRepositorio
                             )
        {
            _mapper = mapper;
            _tipoNormaRepositorio = tipoNormaRepositorio;
        }

        /*public async Task<OperacionDto<RespuestaSimpleDto<string>>> CrearOActualizarAsync(SectorDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<RespuestaSimpleDto<string>>(peticion);

            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<int>(peticion.Id);

            var entidad = await _sectorRepositorio.BuscarPorIdAsync(id);

            if (entidad == null)
            {
                entidad = new Sector();
            }

            entidad.Codigo = peticion.Codigo;
            entidad.Descripcion = peticion.Descripcion;

            if (entidad.Id == 0)
            {
                var validarCodigo = await _sectorRepositorio.BuscarPorCodigoAsync(peticion.Codigo);
                if (validarCodigo != null)
                {
                    if (validarCodigo.Estado == 0)
                    {
                        validarCodigo.Estado = 1;
                        _sectorRepositorio.Editar(validarCodigo);
                    }
                    else
                    {
                        return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "El codigo ingresado ya existe");
                    }
                }
                else
                {
                    _sectorRepositorio.Insertar(entidad);
                }
            }
            else
            {
                _sectorRepositorio.Editar(entidad);
            }
            await _sectorRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Id = RijndaelUtilitario.EncryptRijndaelToUrl(entidad.Id),
                    Mensaje = "Se guardó con éxito."
                });

        }*/

        /*public async Task<OperacionDto<RespuestaSimpleDto<string>>> EliminarAsync(string idSectorCifrado)
        {
            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<long>(idSectorCifrado);
            var entidad = await _sectorRepositorio.BuscarPorIdYNoBorradoAsync(id);
            if (entidad == null)
            {
                return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.NoExiste, "Sector no existe");
            }
            entidad.Estado = 0;
            _sectorRepositorio.Editar(entidad);

            await _sectorRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Mensaje = "Eliminado correctamente"
                });
        }*/

        /*public async Task<OperacionDto<SectorDto>> ObtenerAsync(string idPerfilCifrado)
        {
            var id = RijndaelUtilitario.DecryptRijndaelFromUrl<long>(idPerfilCifrado);
            var entidad = await _sectorRepositorio.BuscarPorIdAsync(id);
            if (entidad == null)
            {
                return new OperacionDto<SectorDto>(CodigosOperacionDto.NoExiste, "Sector no existe");
            }

            var dto = _mapper.Map<SectorDto>(entidad);
            return new OperacionDto<SectorDto>(dto);
        }*/

        public async Task<OperacionDto<List<TipoNormaDto>>> ListarAsync()
        {
            var entidad = await _tipoNormaRepositorio.ListarAsync();

            var dto = _mapper.Map<List<TipoNormaDto>>(entidad);
            return new OperacionDto<List<TipoNormaDto>>(dto);
        }
    }
}
