using Jazani.Comunes.Base.ApiWeb.Base;
using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using Jazani.ICL.Servicios.Auth.Usuarios.Servicios.Abstracciones;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jazani.ICL.ApiWeb.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiControladorBase
    {
        private readonly ILoginServicio _usuarioLoginServicio;
        public AuthController(
                              ILoginServicio usuarioLoginServicio
                             )
        {
            _usuarioLoginServicio = usuarioLoginServicio;
        }

        [HttpPost("Login")]
        public async Task<LoginRespuestaDto> Login(LoginPeticionDto peticion)
        {
            VerificarIfEsBuenJson(peticion);
            var operacion = await _usuarioLoginServicio.LoginAsync(peticion);

            return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        }
    }
}
