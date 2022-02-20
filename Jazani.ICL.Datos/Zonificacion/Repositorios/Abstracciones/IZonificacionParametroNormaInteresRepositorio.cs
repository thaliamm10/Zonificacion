using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Abstracciones;
using Jazani.ICL.Datos.Zonificacion.Entidades;

namespace Jazani.ICL.Datos.Zonificacion.Repositorios.Abstracciones
{
    public interface IZonificacionParametroNormaInteresRepositorio:IICLRepositorio<ZonificacionParametroNormaInteres,long>
    {
        Task<ZonificacionParametroNormaInteres> BuscarPorIdNormaInteresAsync(long IdNormaInteres);

        Task<List<ZonificacionParametroNormaInteres>> ListarAsync();
        Task<Tuple<List<ZonificacionParametroNormaInteres>, int>> ListarPaginadoAsync(string orden, int start,
            int length, string zonificacion = null
        );
    }
}