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

        public async Task<OperacionDto<List<TipoProcedimientoDto>>> ListarAsync()
        {
            var tipoProcedimientos = await _tipoProcedimientoRepositorio.ListarAsync();

            var dto = _mapper.Map<List<TipoProcedimientoDto>>(tipoProcedimientos);
            return new OperacionDto<List<TipoProcedimientoDto>>(dto);
        }

        public async Task<OperacionDto<List<TipoProcedimientoDto>>> ListarPaginadoAsync(int start, int length)
        {
            var tipoProcedimiento = await _tipoProcedimientoRepositorio.ListarPaginadoAsync(start, length);

            var dto = _mapper.Map<List<TipoProcedimientoDto>>(tipoProcedimiento);
            return new OperacionDto<List<TipoProcedimientoDto>>(dto);
        }

        public async Task<OperacionDto<List<TipoProcedimientoDto>>> RegistrarAsync(TipoProcedimientoDto tipoProcedimientoDto)
        {
            //VerificarIfEsBuenJson(tipoProcedimientoDto);
            TipoProcedimiento tipoProcedimiento = new TipoProcedimiento();
            var idTproc = 0;
            if (tipoProcedimientoDto.Id != "NULL")
            {
                idTproc = RijndaelUtilitario.DecryptRijndaelFromUrl<int>(tipoProcedimientoDto.Id);
            }
            
            tipoProcedimiento.Id = idTproc;
            tipoProcedimiento.Nombre = tipoProcedimientoDto.Nombre;

            var obj_registro = await _tipoProcedimientoRepositorio.RegistrarAsync(tipoProcedimiento);

            var dto = _mapper.Map<List<TipoProcedimientoDto>>(obj_registro);
            return new OperacionDto<List<TipoProcedimientoDto>>(dto);
        }
    }
}
