using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosServicios
    {
        private static DataTable DT = new DataTable();
        private static int Estado = 0;

        public static DataTable AgregarServicio(EntidadServicios Entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(Entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPAgregarServicio");
                Comando.Parameters.AddWithValue("@_TxtServicio", Entidad.TxtServicio);
                Comando.Parameters.AddWithValue("@_TxtToken", Entidad.txtToken);

                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable ActualizarServicio(EntidadServicios Entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(Entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPActualizarServicio");
                Comando.Parameters.AddWithValue("@_IdRegistro", Entidad.IdServicio);
                Comando.Parameters.AddWithValue("@_TxtServicio", Entidad.TxtServicio);

                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable ObtenerServicios(EntidadServicios entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPObtenerServicios");
                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable ObtenerDatosServicio(EntidadServicios entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPObtenerDatosServicio");
                Comando.Parameters.AddWithValue("@_IdRegistro", entidad.IdServicio);

                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable EliminarServicio(EntidadServicios entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPEliminarServicio");
                Comando.Parameters.AddWithValue("@_IdRegistro", entidad.IdServicio);

                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }
    }
}