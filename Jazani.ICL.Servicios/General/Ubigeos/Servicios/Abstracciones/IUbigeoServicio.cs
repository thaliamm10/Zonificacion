using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.General.Ubigeo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Ubigeos.Servicios
{
    public interface IUbigeoServicio
    {
        Task<OperacionDto<List<UbigeoDto>>> ListarAsync();
    }
}
