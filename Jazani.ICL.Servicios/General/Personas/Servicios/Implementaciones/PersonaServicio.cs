using Jazani.Comunes.Utilitarios.Infraestructura.Dtos;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Datos.General.Repositorio.Abstracciones;
using Jazani.ICL.Servicios.General.Personas.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Personas.Servicios.Implementaciones
{
    public class PersonaServicio
    {
        private readonly IPersonaRepositorio _personaRepositorio;
        public PersonaServicio(
                               IPersonaRepositorio personaRepositorio
                              )
        {
            _personaRepositorio = personaRepositorio;
        }

        public async Task<OperacionDto<RespuestaSimpleDto<string>>> CrearAsync(PersonaDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<RespuestaSimpleDto<string>>(peticion);

            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var persona = new Persona();

            persona.Nombre = peticion.Nombre;
            persona.Paterno = peticion.Paterno;
            persona.Materno = peticion.Materno;
            persona.Correo = peticion.Correo;
            persona.IdDocumentoIdentidad = 1;
            persona.Documento = peticion.Documento;
            persona.Telefono = peticion.Telefono;
            persona.Direccion = peticion.Direccion;
            //persona.IdArea = peticion.Area.Id;

            var validarDocumento = await _personaRepositorio.BuscarPorDocumentoAsync(peticion.Documento);
            if (validarDocumento != null)
            {
                if (validarDocumento.Estado == 0)
                {
                    validarDocumento.Estado = 1;
                    _personaRepositorio.Editar(validarDocumento);
                }
                else
                {
                    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "El nombre ingresado ya existe");
                }
            }
            else
            {
                _personaRepositorio.Insertar(persona);
            }

            _personaRepositorio.Insertar(persona);
            await _personaRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return new OperacionDto<RespuestaSimpleDto<string>>(
                new RespuestaSimpleDto<string>()
                {
                    Id = RijndaelUtilitario.EncryptRijndaelToUrl(persona.Id),
                    Mensaje = "Se guardó correctamente"
                });

        }
    }
}
