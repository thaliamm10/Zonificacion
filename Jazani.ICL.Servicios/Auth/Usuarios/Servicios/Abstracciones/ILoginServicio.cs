using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.Auth.Usuarios.Servicios.Abstracciones
{
    public interface ILoginServicio
    {
        Task<OperacionDto<LoginRespuestaDto>> LoginAsync(LoginPeticionDto peticion);
    }
}
