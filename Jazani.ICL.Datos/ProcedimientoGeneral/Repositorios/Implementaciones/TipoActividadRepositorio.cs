using Jazani.ICL.Datos.Infraestructura.Configuraciones.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Repositorios.Implementaciones;
using Jazani.ICL.Datos.ProcedimientoGeneral.Entidades;
using Jazani.ICL.Datos.ProcedimientoGeneral.Repositorios.Abstracciones;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Datos.ProcedimientoGeneral.Repositorios.Implementaciones
{
    public class TipoActividadRepositorio : ICLRepositorio<TipoActividad, int>, ITipoActividadRepositorio
    {
        public TipoActividadRepositorio(IICLUnidadDeTrabajo unidadDeTrabajo, IICLConfiguracion configuracion) : base(unidadDeTrabajo, configuracion) { }

        public async Task<TipoActividad> EliminarAsync(int Id)
        {
            TipoActividad obj_response = new TipoActividad();
            var sql = "PKG_ADMINISTRAR_TACTIVIDAD.SP_ELIMINAR";

            using (var conexion = new OracleConnection(Configuracion.CadenaConexion))
            {
                using var comando = new OracleCommand(sql, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new OracleParameter("@P_ID", OracleDbType.Int16, Id, ParameterDirection.Input));
                comando.Parameters.Add(new OracleParameter("@P_C_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
                conexion.Open();
                using var reader = await comando.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    obj_response = new TipoActividad
                    {
                        Id = !reader.IsDBNull(reader.GetOrdinal("ID_TIPO_ACTIVIDAD")) ? reader.GetInt32(reader.GetOrdinal("ID_TIPO_ACTIVIDAD")) : 0,
                        Nombre = !reader.IsDBNull(reader.GetOrdinal("NOMBRE")) ? reader.GetString(reader.GetOrdinal("NOMBRE")) : null,
                        FechaRegistro = !reader.IsDBNull(reader.GetOrdinal("FECHA_REGISTRO")) ? reader.GetDateTime(reader.GetOrdinal("FECHA_REGISTRO")) : DateTime.UtcNow,
                        Estado = !reader.IsDBNull(reader.GetOrdinal("ESTADO")) ? reader.GetInt16(reader.GetOrdinal("ESTADO")) : 0
                    };
                }
            }

            return obj_response;
        }

        public async Task<List<TipoActividad>> ListarAsync()
        {
            var lista = new List<TipoActividad>();
            var sql = "PKG_ADMINISTRAR_TACTIVIDAD.SP_LISTAR";

            using (var conexion = new OracleConnection(Configuracion.CadenaConexion))
            {
                using var comando = new OracleCommand(sql, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new OracleParameter("@P_C_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
                conexion.Open();
                using var reader = await comando.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var data = new TipoActividad
                    {
                        Id = !reader.IsDBNull(reader.GetOrdinal("ID_TIPO_ACTIVIDAD")) ? reader.GetInt32(reader.GetOrdinal("ID_TIPO_ACTIVIDAD")) : 0,
                        Nombre = !reader.IsDBNull(reader.GetOrdinal("NOMBRE")) ? reader.GetString(reader.GetOrdinal("NOMBRE")) : null,
                        FechaRegistro = !reader.IsDBNull(reader.GetOrdinal("FECHA_REGISTRO")) ? reader.GetDateTime(reader.GetOrdinal("FECHA_REGISTRO")) : DateTime.UtcNow,
                        Estado = !reader.IsDBNull(reader.GetOrdinal("ESTADO")) ? reader.GetInt16(reader.GetOrdinal("ESTADO")) : 0
                    };
                    lista.Add(data);
                }
            }
            return lista;
        }

        public async Task<TipoActividad> RegistrarAsync(TipoActividad tipoActividad)
        {
            TipoActividad obj_response = new TipoActividad();
            var sql = "PKG_ADMINISTRAR_TACTIVIDAD.SP_REGISTRAR";

            using (var conexion = new OracleConnection(Configuracion.CadenaConexion))
            {
                using var comando = new OracleCommand(sql, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new OracleParameter("@P_ID", OracleDbType.Int16, tipoActividad.Id, ParameterDirection.Input));
                comando.Parameters.Add(new OracleParameter("@P_NOMBRE", OracleDbType.Varchar2, tipoActividad.Nombre, ParameterDirection.Input));
                comando.Parameters.Add(new OracleParameter("@P_C_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
                conexion.Open();
                using var reader = await comando.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    obj_response = new TipoActividad
                    {
                        Id = !reader.IsDBNull(reader.GetOrdinal("ID_TIPO_ACTIVIDAD")) ? reader.GetInt32(reader.GetOrdinal("ID_TIPO_ACTIVIDAD")) : 0,
                        Nombre = !reader.IsDBNull(reader.GetOrdinal("NOMBRE")) ? reader.GetString(reader.GetOrdinal("NOMBRE")) : null,
                        FechaRegistro = !reader.IsDBNull(reader.GetOrdinal("FECHA_REGISTRO")) ? reader.GetDateTime(reader.GetOrdinal("FECHA_REGISTRO")) : DateTime.UtcNow,
                        Estado = !reader.IsDBNull(reader.GetOrdinal("ESTADO")) ? reader.GetInt16(reader.GetOrdinal("ESTADO")) : 0
                    };
                }
            }

            return obj_response;
        }
    }
}
