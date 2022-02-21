using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.CompendioNormas.Repositorios.Abstracciones;
using Jazani.ICL.Servicios.CompendioNormas.Dtos;
using Jazani.ICL.Servicios.CompendioNormas.Servicios.Abstracciones;

namespace Jazani.ICL.Servicios.CompendioNormas.Servicios.Implementaciones
{
    public class NormaInteresModuloServicio : INormaInteresModuloServicio
    {
        private readonly IMapper _mapper;

        public readonly INormaInteresModuloRepositorio _normaInteresModuloRepositorio;

        public NormaInteresModuloServicio(
            IMapper mapper,
            INormaInteresModuloRepositorio normaInteresModuloRepositorio
        )
        {
            _mapper = mapper;
            _normaInteresModuloRepositorio = normaInteresModuloRepositorio;
        }

        public async Task<OperacionDto<List<NormaInteresModuloDto>>> ListarAsync(string norma, string id_naturaleza, string id_modulo, string fecha_inicio, string fecha_fin)
        {
            var idNaturaleza = RijndaelUtilitario.DecryptRijndaelFromUrl<long>(id_naturaleza);
            var idModulo = RijndaelUtilitario.DecryptRijndaelFromUrl<long>(id_modulo);

            var entidad = await _normaInteresModuloRepositorio.BuscarPorFiltros(
                norma, idNaturaleza, idModulo,fecha_inicio, fecha_fin
            );

            var dto = _mapper.Map<List<NormaInteresModuloDto>>(entidad);
            return new OperacionDto<List<NormaInteresModuloDto>>(dto);
        }
    }
}