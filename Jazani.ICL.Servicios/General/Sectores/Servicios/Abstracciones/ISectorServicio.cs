using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.General.Sectores.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Sectores.Servicios.Abstracciones
{
    public interface ISectorServicio
    {
        /*Task<OperacionDto<RespuestaSimpleDto<string>>> CrearOActualizarAsync(SectorDto peticion);
        Task<OperacionDto<RespuestaSimpleDto<string>>> EliminarAsync(string idSectorCifrado);
        Task<OperacionDto<SectorDto>> ObtenerAsync(string idSectorCifrado);*/
        Task<OperacionDto<List<SectorDto>>> ListarAsync();
        //Task<OperacionDto<JQueryDatatableDto<PerfilDto>>> ListarPaginado(PerfilPaginadoPeticionDto peticion);
    }
}
