using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        private static string usuario = "admin";
        private static string password = "admin";
        private static string servidor = "GODLIKE\\SQLEXPRESS";
        private static string DB = "DBEvaluacion";

        public static string obtenerCadenaConexionSQL()
        {
            return "Persist Security Info = false; User ID = '" + usuario
                        + "'; Password = '" + password
                        + "'; Initial Catalog = '" + DB
                        + "'; Server = '" + servidor + "'";
        }

        //EJECTURAR PROCEDIMIENTO ALMACENADO PASANDOLO COMO PARAMETRO
        public static SqlCommand crearComandoProc(String SP)
        {
            string cadenaConexion = Conexion.obtenerCadenaConexionSQL();
            SqlConnection miConexion = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand(SP, miConexion);
            comando.CommandType = CommandType.StoredProcedure;
            return comando;
        }
        

        /*
         * EjecutarComandoSelect
         */
        public static DataTable ejecutarComandoSelect(SqlCommand comando)
        {
            DataTable dt = new DataTable();
            try
            {
                comando.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                adaptador.Fill(dt);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }
            return dt;
        }

    }

    
}
