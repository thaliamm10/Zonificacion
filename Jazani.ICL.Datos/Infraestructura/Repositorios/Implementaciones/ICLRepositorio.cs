using Jazani.Comunes.DatosEF.Infraestructura.Repositorios.Implementaciones;
using Jazani.ICL.Datos.Infraestructura.Configuraciones.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Infraestructura.Repositorios.Implementaciones
{
    public class ICLRepositorio<TEntidad, TLlave> : EFRepositorio<TEntidad, TLlave, IICLConfiguracion, IICLUnidadDeTrabajo>, IICLRepositorio<TEntidad, TLlave>
         where TEntidad : class
    {
        public ICLRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(unidadDeTrabajo, configuracion)
        {
        }
    }
}
