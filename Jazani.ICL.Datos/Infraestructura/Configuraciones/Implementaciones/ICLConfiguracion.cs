using Jazani.ICL.Datos.Infraestructura.Configuraciones.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Infraestructura.Configuraciones.Implementaciones
{
    public class ICLConfiguracion : IICLConfiguracion
    {
        public string CadenaConexion { get; set; }
    }
}
