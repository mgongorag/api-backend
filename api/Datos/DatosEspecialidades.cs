using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosEspecialidades
    {
        private static DataTable DT = new DataTable();
        private static int Estado = 0;

        public static DataTable AgregarEspecialidad(EntidadEspecialidades Entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(Entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPAgregarEspecialidad");
                Comando.Parameters.AddWithValue("@_TxtEspecialidad", Entidad.TxtEspecialidad);
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

        public static DataTable ActualizarEspecialidad(EntidadEspecialidades Entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(Entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPActualizarEspecialidad");
                Comando.Parameters.AddWithValue("@_IdEspecialidad", Entidad.IdEspecialidad);
                Comando.Parameters.AddWithValue("@_TxtEspecialidad", Entidad.TxtEspecialidad);

                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable ObtenerEspecialidades(EntidadEspecialidades entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPObtenerEspecialidades");
                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable ObtenerDatosEspecialidad(EntidadEspecialidades entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPObtenerDatosEspecialidad");
                Comando.Parameters.AddWithValue("@_IdRegistro", entidad.IdEspecialidad);

                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable EliminarEspecialidad(EntidadEspecialidades entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPEliminarEspecialidad");
                Comando.Parameters.AddWithValue("@_IdRegistro", entidad.IdEspecialidad);

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
