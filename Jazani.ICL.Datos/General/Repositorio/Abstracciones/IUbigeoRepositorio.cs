using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.General.Repositorio.Abstracciones
{
    public interface IUbigeoRepositorio : IICLRepositorio<Ubigeo, long>
    {

        Task<List<Ubigeo>> ListarAsync();
    }
}
