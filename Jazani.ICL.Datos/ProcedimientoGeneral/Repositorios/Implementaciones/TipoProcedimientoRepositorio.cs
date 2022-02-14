using Jazani.ICL.Datos.Infraestructura.Configuraciones.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Implementaciones;
using Jazani.ICL.Datos.ProcedimientoGeneral.Entidades;
using Jazani.ICL.Datos.ProcedimientoGeneral.Repositorios.Abstracciones;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.ProcedimientoGeneral.Repositorios.Implementaciones
{
    public class TipoProcedimientoRepositorio : ICLRepositorio<TipoProcedimiento, int>, ITipoProcedimientoRepositorio
    {
        public TipoProcedimientoRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(unidadDeTrabajo, configuracion) { }

        //public async Task<List<TipoProcedimiento>> ListarAsync()
        //    => await UnidadDeTrabajo.TipoProcedimientos.Where(e => e.Estado == 1).ToListAsync();

        public async Task<List<TipoProcedimiento>> ListarAsync()
        {
            var lista = new List<TipoProcedimiento>();
            var sql = "PKG_ADMINISTRAR_TPROCEDIMIENTO.SP_LISTAR";

            using (var conexion = new OracleConnection(Configuracion.CadenaConexion))
            {
                using var comando = new OracleCommand(sql, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new OracleParameter("@P_C_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
                conexion.Open();
                using var reader = await comando.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var data = new TipoProcedimiento
                    {
                        Id = !reader.IsDBNull(reader.GetOrdinal("ID_TIPO_PROCEDIMIENTO")) ? reader.GetInt32(reader.GetOrdinal("ID_TIPO_PROCEDIMIENTO")) : 0,
                        Nombre = !reader.IsDBNull(reader.GetOrdinal("NOMBRE")) ? reader.GetString(reader.GetOrdinal("NOMBRE")) : null,
                        FechaRegistro = !reader.IsDBNull(reader.GetOrdinal("FECHA_REGISTRO")) ? reader.GetDateTime(reader.GetOrdinal("FECHA_REGISTRO")) : DateTime.UtcNow,
                        Estado = !reader.IsDBNull(reader.GetOrdinal("ESTADO")) ? reader.GetInt16(reader.GetOrdinal("ESTADO")) : 0 
                    };
                    lista.Add(data);
                }
            }
            return lista;
        }

        public async Task<List<TipoProcedimiento>> ListarPaginadoAsync(int start, int length)
        {
            var lista = new List<TipoProcedimiento>();
            var sql = "PKG_ADMINISTRAR_TPROCEDIMIENTO.SP_LISTAR_PAGINADO";

            using (var conexion = new OracleConnection(Configuracion.CadenaConexion))
            {
                using var comando = new OracleCommand(sql, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new OracleParameter("@P_C_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
                comando.Parameters.Add(new OracleParameter("@P_START", OracleDbType.Int16, start, ParameterDirection.Input));
                comando.Parameters.Add(new OracleParameter("@P_LENGTH", OracleDbType.Int16, length, ParameterDirection.Input));
                conexion.Open();
                using var reader = await comando.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var data = new TipoProcedimiento
                    {
                        Id = !reader.IsDBNull(reader.GetOrdinal("ID_TIPO_PROCEDIMIENTO")) ? reader.GetInt32(reader.GetOrdinal("ID_TIPO_PROCEDIMIENTO")) : 0,
                        Nombre = !reader.IsDBNull(reader.GetOrdinal("NOMBRE")) ? reader.GetString(reader.GetOrdinal("NOMBRE")) : null,
                        FechaRegistro = !reader.IsDBNull(reader.GetOrdinal("FECHA_REGISTRO")) ? reader.GetDateTime(reader.GetOrdinal("FECHA_REGISTRO")) : DateTime.UtcNow,
                        Estado = !reader.IsDBNull(reader.GetOrdinal("ESTADO")) ? reader.GetInt16(reader.GetOrdinal("ESTADO")) : 0
                    };
                    lista.Add(data);
                }
            }
            return lista;
        }
    }
}
