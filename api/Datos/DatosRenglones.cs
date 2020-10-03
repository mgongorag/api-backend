using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosRenglones
    {

        private static readonly Funciones Funciones = new Funciones();
        private static DataTable DT = new DataTable();
        private static int Estado = 0;

        public static DataTable AgregarRenglon(EntidadRenglones Entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(Entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPAgregarRenglone");
                Comando.Parameters.AddWithValue("@_TxtRenglon", Entidad.TxtRenglon);
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

        public static DataTable ActualizarRenglon(EntidadRenglones Entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(Entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPActualizarRenglon");
                Comando.Parameters.AddWithValue("@_IdRegistro", Entidad.IdRenglon);
                Comando.Parameters.AddWithValue("@_TxtRenglon", Entidad.TxtRenglon);

                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable ObtenerRenglones(EntidadRenglones entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPObtenerRenglones");
                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable ObtenerDatosRenglon(EntidadRenglones entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPObtenerDatosRenglon");
                Comando.Parameters.AddWithValue("@_IdRegistro", entidad.IdRenglon);

                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable EliminarRenglon(EntidadRenglones entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPEliminarRenglon");
                Comando.Parameters.AddWithValue("@_IdRegistro", entidad.IdRenglon);

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
