using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Usuarios
    {
        private static readonly Funciones funciones = new Funciones();

        public static DataTable agregarUsuario(Entidades.Usuarios Entidad)
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


    }
}
