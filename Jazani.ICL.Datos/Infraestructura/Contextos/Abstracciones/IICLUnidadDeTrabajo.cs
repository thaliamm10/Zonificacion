using Jazani.Comunes.DatosEF.Infraestructura.Contexto.Abstracciones;
using Jazani.ICL.Datos.Auth.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones
{
    public interface IICLUnidadDeTrabajo : IEFUnidadDeTrabajo
    {
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
