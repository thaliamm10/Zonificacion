using Jazani.Comunes.DatosEF.Infraestructura.Repositorios.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Infraestructura.Repositorios.Abstracciones
{
    public interface IICLRepositorio<TEntidad, TLlave> : IEFRepositorio<TEntidad, TLlave, IICLUnidadDeTrabajo>
       where TEntidad : class
    {
    }
}
