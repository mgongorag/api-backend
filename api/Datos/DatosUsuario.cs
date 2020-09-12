using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class DatosUsuario
    {
        private static readonly Funciones funciones = new Funciones();
        private static readonly int vigenciaEnMinutos = 30;
        private static DataTable dt = new DataTable();
        private static int estado = 0;

        public static DataTable agregarUsuario(Entidades.EntidadUsuarios Entidad)
        {
            estado = ObtenerEstadoToken(Entidad.txtToken);

            // 0 expirado, 1 vigente
            if (estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("Sesion.SPAgregarUsuario");
                Comando.Parameters.AddWithValue("@_TxtNombres", Entidad.TxtNombres);
                Comando.Parameters.AddWithValue("@_TxtApellidos", Entidad.TxtApellidos);
                Comando.Parameters.AddWithValue("@_TxtDireccion", Entidad.TxtDireccion);
                Comando.Parameters.AddWithValue("@_TxtEmail", Entidad.TxtEmail);
                Comando.Parameters.AddWithValue("@_TxtPassword", Funciones.SeguridadSHA521(Entidad.TxtPassword));
                Comando.Parameters.AddWithValue("@_TxtToken", Entidad.txtToken);

                dt = Conexion.ejecutarComandoSelect(Comando);
                dt = AgregarEstadoToken(dt, estado.ToString());
            }
            else
            {
                dt = AgregarEstadoToken(dt, "0");
            }

            return dt;
        }

        public static DataTable obtenerUsuarios()
        {
            SqlCommand comando = Conexion.crearComandoProc("Sesion.SPObtenerUsuarios");
            return Conexion.ejecutarComandoSelect(comando);
        }


        public static DataTable obtenerDatosUsuario(Entidades.EntidadUsuarios Entidad)
        {
         

            SqlCommand comando = Conexion.crearComandoProc("Sesion.SPObtenerDatosUsuarios");
            comando.Parameters.AddWithValue("@_IdUsuario", Entidad.idUsuario);

            return Conexion.ejecutarComandoSelect(comando);
           
        }

        public static DataTable eliminarUsuario(Entidades.EntidadUsuarios Entidad)
        {

            SqlCommand comando = Conexion.crearComandoProc("Sesion.SPEliminarUsuario");
            comando.Parameters.AddWithValue("@_IdUsuario", Entidad.idUsuario);

            return Conexion.ejecutarComandoSelect(comando);
        }

        public static DataTable actualizarUsuario(Entidades.EntidadUsuarios Entidad)
        {

            SqlCommand comando = Conexion.crearComandoProc("Sesion.SPActualizarUsuario");
            comando.Parameters.AddWithValue("@_IdUsuario", Entidad.idUsuario);
            comando.Parameters.AddWithValue("@_TxtNombres", Entidad.TxtNombres);
            comando.Parameters.AddWithValue("@_TxtApellidos", Entidad.TxtApellidos);
            comando.Parameters.AddWithValue("@_TxtDireccion", Entidad.TxtDireccion);
            comando.Parameters.AddWithValue("@_TxtEmail", Entidad.TxtEmail);
            comando.Parameters.AddWithValue("@_TxtPassword", Funciones.SeguridadSHA521(Entidad.TxtPassword));
            //comando.Parameters.AddWithValue("@_TxtToken", funciones.generarTokenDeSession);

            return Conexion.ejecutarComandoSelect(comando);
            
        }

      
        public static DataTable inicioDeSesion(Entidades.EntidadUsuarios Entidad)
        {
           
            SqlCommand comando = Conexion.crearComandoProc("Sesion.SPInicioDeSesion");
            comando.Parameters.AddWithValue("@_TxtEmail", Entidad.TxtEmail);
            comando.Parameters.AddWithValue("@_TxtPassword", Funciones.SeguridadSHA521(Entidad.TxtPassword));
            comando.Parameters.AddWithValue("@_TxtToken", Funciones.generarTokenSesion());
            comando.Parameters.AddWithValue("@_VigenciaEnMinutos", vigenciaEnMinutos);

            return Conexion.ejecutarComandoSelect(comando);
        }




        public static int ObtenerEstadoToken(string TxtToken)
        {
            SqlCommand Comando = Conexion.crearComandoProc("Sesion.SPObtenerEstadoToken");
            Comando.Parameters.AddWithValue("@_TxtToken", TxtToken);

            dt.Reset();
            dt.Clear();

            dt = Conexion.ejecutarComandoSelect(Comando);
            return Convert.ToInt32(dt.Rows[0][0].ToString());
        }

        public static DataTable AgregarEstadoToken(DataTable DT, string Estado)
        {
            if (DT.Rows.Count > 0)
            {
                DT.Columns.Add("EstatoToken", typeof(string), Estado).SetOrdinal(0);
            }
            else
            {
                DT.Reset();
                DT.Clear();

                try
                {
                    DataColumn Col = new DataColumn();
                    Col.ColumnName = "EstadoToken";
                    DT.Columns.Add(Col);

                    DataRow Fila = DT.NewRow();
                    Fila["EstadoToken"] = Estado;
                    DT.Rows.Add(Fila);
                }
                catch
                {
                    DataRow Fila = DT.NewRow();
                    Fila["EstadoToken"] = Estado;
                    DT.Rows.Add(Fila);
                }
            }
            return DT;
        }

        //Agregar el estado del token a cada table o set de datos
       



    }
}
