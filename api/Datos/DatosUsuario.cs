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

        public static DataTable agregarUsuario(Entidades.EntidadUsuarios Entidad)
        {
            DataTable dt = new DataTable();

            SqlCommand comando = Conexion.crearComandoProc("Sesion.SPAgregarUsuario");
            comando.Parameters.AddWithValue("@_TxtNombres", Entidad.TxtNombres);
            comando.Parameters.AddWithValue("@_TxtApellidos", Entidad.TxtApellidos);
            comando.Parameters.AddWithValue("@_TxtDireccion", Entidad.TxtDireccion);
            comando.Parameters.AddWithValue("@_TxtEmail", Entidad.TxtEmail);
            comando.Parameters.AddWithValue("@_TxtPassword", funciones.SeguridadSHA521(Entidad.TxtPassword));
            //comando.Parameters.AddWithValue("@_TxtToken", funciones.generarTokenDeSession);

            dt = Conexion.ejecutarComandoSelect(comando);
            return  dt;
        }

        public static DataTable obtenerUsuarios()
        {
            DataTable dt = new DataTable();

            SqlCommand comando = Conexion.crearComandoProc("Sesion.SPObtenerUsuarios");

            dt = Conexion.ejecutarComandoSelect(comando);
            return dt;
        }


        public static DataTable obtenerDatosUsuario(Entidades.EntidadUsuarios Entidad)
        {
            DataTable dt = new DataTable();

            SqlCommand comando = Conexion.crearComandoProc("Sesion.SPObtenerDatosUsuarios");
            comando.Parameters.AddWithValue("@_IdUsuario", Entidad.idUsuario);

            dt = Conexion.ejecutarComandoSelect(comando);
            return dt;
        }

        public static DataTable eliminarUsuario(Entidades.EntidadUsuarios Entidad)
        {
            DataTable dt = new DataTable();

            SqlCommand comando = Conexion.crearComandoProc("Sesion.SPEliminarUsuario");
            comando.Parameters.AddWithValue("@_IdUsuario", Entidad.idUsuario);

            dt = Conexion.ejecutarComandoSelect(comando);
            return dt;
        }

        public static DataTable actualizarUsuario(Entidades.EntidadUsuarios Entidad)
        {
            DataTable dt = new DataTable();

            SqlCommand comando = Conexion.crearComandoProc("Sesion.SPActualizarUsuario");
            comando.Parameters.AddWithValue("@_IdUsuario", Entidad.idUsuario);
            comando.Parameters.AddWithValue("@_TxtNombres", Entidad.TxtNombres);
            comando.Parameters.AddWithValue("@_TxtApellidos", Entidad.TxtApellidos);
            comando.Parameters.AddWithValue("@_TxtDireccion", Entidad.TxtDireccion);
            comando.Parameters.AddWithValue("@_TxtEmail", Entidad.TxtEmail);
            comando.Parameters.AddWithValue("@_TxtPassword", funciones.SeguridadSHA521(Entidad.TxtPassword));
            //comando.Parameters.AddWithValue("@_TxtToken", funciones.generarTokenDeSession);

            dt = Conexion.ejecutarComandoSelect(comando);
            return dt;
        }

    }
}
