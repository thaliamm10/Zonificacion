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
        public async Task<OperacionDto<TipoActividadDto>> EliminarAsync(string id)
        {
            var idTipoActividad = RijndaelUtilitario.DecryptRijndaelFromUrl<int>(id);

            var obj_response = await _tipoActividadRepositorio.EliminarAsync(idTipoActividad);

            var dto = _mapper.Map<TipoActividadDto>(obj_response);
            return new OperacionDto<TipoActividadDto>(dto);
        }

        public async Task<OperacionDto<List<TipoActividadDto>>> ListarAsync()
        {
            var tipoActividades = await _tipoActividadRepositorio.ListarAsync();

            var dto = _mapper.Map<List<TipoActividadDto>>(tipoActividades);
            return new OperacionDto<List<TipoActividadDto>>(dto);
        }

        public async Task<OperacionDto<TipoActividadDto>> RegistrarAsync(TipoActividadDto tipoActividadDto)
        {
            TipoActividad tipoActividad = new TipoActividad();
            var idTipoActividad = 0;
            if (tipoActividadDto.Id != "NULL")
            {
                idTipoActividad = RijndaelUtilitario.DecryptRijndaelFromUrl<int>(tipoActividadDto.Id);
            }

            tipoActividad.Id = idTipoActividad;
            tipoActividad.Nombre = tipoActividadDto.Nombre;

            var obj_registro = await _tipoActividadRepositorio.RegistrarAsync(tipoActividad);

            var dto = _mapper.Map<TipoActividadDto>(obj_registro);
            return new OperacionDto<TipoActividadDto>(dto);
        }
    }
}
