using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.CompendioNormas.Repositorios.Abstracciones;
using Jazani.ICL.Datos.General.Repositorio.Abstracciones;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;
using Jazani.ICL.Servicios.CompendioNormas.Servicios.Abstracciones;
using Jazani.ICL.Servicios.General.Sectores.Servicios.Abstracciones;

namespace Jazani.ICL.Servicios.CompendioNormas.Servicios.Implementaciones
{
    public class NormaInteresFiltroServicio: INormaInteresFiltroServicio
    {
        private readonly IMapper _mapper;

        public readonly INormaInteresFiltroRepositorio _normaInteresRepositorio;

        public NormaInteresFiltroServicio(
            IMapper mapper,
            INormaInteresFiltroRepositorio normaInteresRepositorio
        )
        {
            _mapper = mapper;
            _normaInteresRepositorio = normaInteresRepositorio;
        }

        public async Task<OperacionDto<List<NormaInteresFiltroDto>>> ListarAsync(
            string norma, string id_naturaleza, string fecha_inicio, string fecha_fin
        )
        {
            var idNaturaleza= RijndaelUtilitario.DecryptRijndaelFromUrl<long>(id_naturaleza);
            var entidad = await _normaInteresRepositorio.BuscarPorFiltros(
                norma,idNaturaleza,fecha_inicio,fecha_fin
                ) ;

            var dto = _mapper.Map<List<NormaInteresFiltroDto>>(entidad);
            return new OperacionDto<List<NormaInteresFiltroDto>>(dto);
        }
    }
}