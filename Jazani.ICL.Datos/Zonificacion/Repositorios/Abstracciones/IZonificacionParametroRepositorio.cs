using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Abstracciones;
using Jazani.ICL.Datos.Zonificacion.Entidades;

namespace Jazani.ICL.Datos.Zonificacion.Repositorios.Abstracciones
{
    public interface IZonificacionParametroRepositorio:IICLRepositorio<ZonificacionParametro,long>
    {

        Task<ZonificacionParametro> BuscarPorZonificacionAsync(string zonificacion);

        Task<List<ZonificacionParametro>> ListarAsync();
        Task<Tuple<List<ZonificacionParametro>, int>> ListarPaginadoAsync(string orden, int start, int length, string zonificacion = null);

    }
}