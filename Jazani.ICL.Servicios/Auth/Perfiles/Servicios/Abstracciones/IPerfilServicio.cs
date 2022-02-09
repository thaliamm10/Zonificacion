using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.Auth.Perfiles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Perfiles.Servicios.Abstracciones
{
    public interface IPerfilServicio
    {
        Task<OperacionDto<RespuestaSimpleDto<string>>> CrearOActualizarAsync(PerfilDto peticion);
        Task<OperacionDto<RespuestaSimpleDto<string>>> EliminarAsync(string idPerfilCifrado);
        Task<OperacionDto<PerfilDto>> ObtenerAsync(string idPerfilCifrado);
        Task<OperacionDto<List<PerfilDto>>> ListarAsync();
        Task<OperacionDto<JQueryDatatableDto<PerfilDto>>> ListarPaginado(PerfilPaginadoPeticionDto peticion);
    }
}
