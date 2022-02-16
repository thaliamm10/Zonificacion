using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Datos.General.Repositorio.Abstracciones;
using Jazani.ICL.Servicios.General.Ubigeo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Ubigeos.Servicios.Implementaciones
{
    public class UbigeoServicio : IUbigeoServicio
    {
        private readonly IMapper _mapper;
        private readonly IUbigeoRepositorio _ubigeoRepositorio;

        public UbigeoServicio(IMapper mapper,
            IUbigeoRepositorio ubigeoRepositorio
            )
        {
            _mapper = mapper;
            _ubigeoRepositorio = ubigeoRepositorio;
        }

        public async Task<OperacionDto<List<UbigeoDto>>> ListarAsync()
        {
            var ubigeos = await _ubigeoRepositorio.ListarAsync();
            var dto = _mapper.Map<List<UbigeoDto>>(ubigeos);
            return new OperacionDto<List<UbigeoDto>>(dto);
        }
    }
}
