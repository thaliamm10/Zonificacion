using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Datos.ProcedimientoGeneral.Repositorios.Abstracciones;
using Jazani.ICL.Servicios.ProcedimientoGeneral.Dtos;
using Jazani.ICL.Servicios.ProcedimientoGeneral.Servicios.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.ProcedimientoGeneral.Procedimientos.Servicios.Implementaciones
{
    class ProcedimientoServicio : IProcedimientoServicio
    {
        private readonly IMapper _mapper;
        private readonly IProcedimientoRepositorio _procedimientoRepositorio;

        public ProcedimientoServicio(
                IMapper mapper,
                IProcedimientoRepositorio procedimientoRepositorio
            )
        {
            _mapper = mapper;
            _procedimientoRepositorio = procedimientoRepositorio;
        }

        public  Task<OperacionDto<RespuestaSimpleDto<string>>> CrearOActualizarAsync(ProcedimientoDto procedimientoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<OperacionDto<List<ProcedimientoDto>>> ListarAsync(string nombre, int estado)
        {
            var json_data = await _procedimientoRepositorio.ListarAsync(nombre, estado);

            var dto = _mapper.Map<List<ProcedimientoDto>>(json_data);
            return new OperacionDto<List<ProcedimientoDto>>(dto);
        }
    }
}
