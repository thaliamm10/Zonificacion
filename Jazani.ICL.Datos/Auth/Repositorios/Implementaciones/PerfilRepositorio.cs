using Jazani.ICL.Datos.Auth.Entidades;
using Jazani.ICL.Datos.Auth.Procedimientos;
using Jazani.ICL.Datos.Auth.Repositorios.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Configuraciones.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.Auth.Repositorios.Implementaciones
{
    public class PerfilRepositorio : ICLRepositorio<Perfil, long>, IPerfilRepositorio
    {
        public PerfilRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(unidadDeTrabajo, configuracion) { }

        public override async Task<Perfil> BuscarPorIdYNoBorradoAsync(long id)
        => await UnidadDeTrabajo.Perfiles.Where(e => e.Id == id && e.Estado == 1).FirstOrDefaultAsync();
        public override async Task<Perfil> BuscarPorIdAsync(long id)
        => await UnidadDeTrabajo.Perfiles.Where(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<Perfil> BuscarPorNombreAsync(string nombre)
        => await UnidadDeTrabajo.Perfiles.Where(x => x.Nombre == nombre).FirstOrDefaultAsync();

        public async Task<List<Perfil>> ListarAsync()
        => await UnidadDeTrabajo.Perfiles.Where(e => e.Estado == 1).ToListAsync();

        public async Task<Tuple<List<Perfil>, int>> ListarPaginadoAsync(string orden, int start, int length,string nombre=null)
        {

            var query = UnidadDeTrabajo.Perfiles
              .Where(e =>
               e.Estado == 1
               && (string.IsNullOrWhiteSpace(nombre) || e.Nombre.StartsWith(nombre))
              );


            var total = query.Count();

            switch (orden)
            {
                case "id":
                    query = query.OrderBy(e => e.Id);
                    break;
                case "id DESC":
                    query = query.OrderByDescending(e => e.Id);
                    break;
                case "nombre":
                    query = query.OrderBy(e => e.Nombre);
                    break;
                case "nombre DESC":
                    query = query.OrderByDescending(e => e.Nombre);
                    break;
            }

            query = query.Skip(start).Take(length);
            var resultados = await query.ToListAsync();
            return new Tuple<List<Perfil>, int>(resultados, total);

        }

        public async Task<List<ObtenerPerfiles>> ObtenerListaAsync()
        {
            var lista = new List<ObtenerPerfiles>();
            var sql = "PKG_SEGURIDAD.usp_listar_perfiles";

            using (var conexion = new OracleConnection(Configuracion.CadenaConexion))
            {
                using var comando = new OracleCommand(sql, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //comando.Parameters.Add(new OracleParameter("@p_nombre", OracleDbType.Varchar2, 800, usuario, ParameterDirection.Input));
                comando.Parameters.Add(new OracleParameter("@p_lista", OracleDbType.RefCursor, ParameterDirection.Output));
                conexion.Open();
                using var reader = await comando.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var data = new ObtenerPerfiles
                    {
                        Id = !reader.IsDBNull(reader.GetOrdinal("id_perfil")) ? reader.GetInt32(reader.GetOrdinal("id_perfil")) : 0,
                        Nombre = !reader.IsDBNull(reader.GetOrdinal("nombre")) ? reader.GetString(reader.GetOrdinal("nombre")) : null,
                        Descripcion = !reader.IsDBNull(reader.GetOrdinal("descripcion")) ? reader.GetString(reader.GetOrdinal("descripcion")) : null
                    };
                    lista.Add(data);
                }
            }
            return lista;
        }
    }
}
