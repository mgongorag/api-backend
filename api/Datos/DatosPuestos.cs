using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosPuestos
    {

        private static readonly Funciones Funciones = new Funciones();
        private static DataTable DT = new DataTable();
        private static int Estado = 0;

        public static DataTable AgregarPuesto(EntidadPuestos Entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(Entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPAgregarPuestos");
                Comando.Parameters.AddWithValue("@_TxtPuesto", Entidad.TxtPuesto);
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

        public static DataTable ActualizarPuesto(EntidadPuestos Entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(Entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPActualizarPuesto");
                Comando.Parameters.AddWithValue("@_IdRegistro", Entidad.IdPuesto);
                Comando.Parameters.AddWithValue("@_TxtPuesto", Entidad.TxtPuesto);

                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable ObtenerPuestos(EntidadPuestos entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPObtenerPuestos");
                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable ObtenerDatosPuesto(EntidadPuestos entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPObtenerDatosPuesto");
                Comando.Parameters.AddWithValue("@_IdRegistro", entidad.IdPuesto);

                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable EliminarPuesto(EntidadPuestos entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPEliminarPuesto");
                Comando.Parameters.AddWithValue("@_IdRegistro", entidad.IdPuesto);

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
