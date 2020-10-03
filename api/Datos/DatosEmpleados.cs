using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosEmpleados
    {
        private static readonly Funciones Funciones = new Funciones();
        private static DataTable DT = new DataTable();
        private static int Estado = 0;

        public static DataTable AgregarEmpleado(EntidadEmpleados Entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(Entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPAgregarEmpleado");
                Comando.Parameters.AddWithValue("@_TxtNit", Entidad.TxtNit);
                Comando.Parameters.AddWithValue("@_TxtDpi", Entidad.TxtDpi);
                Comando.Parameters.AddWithValue("@_TxtNombres", Entidad.TxtNombres);
                Comando.Parameters.AddWithValue("@_TxtApellidos", Entidad.TxtApellidos);
                Comando.Parameters.AddWithValue("@_IdPuesto", Entidad.IdPuesto);
                Comando.Parameters.AddWithValue("@_IdEspecialidad", Entidad.IdEspecialidad);
                Comando.Parameters.AddWithValue("@_IdServicio", Entidad.IdServicio);
                Comando.Parameters.AddWithValue("@_IdRenglon", Entidad.IdRenglon);
                Comando.Parameters.AddWithValue("@_IdInstitucion", Entidad.idInstitucion);
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

        public static DataTable ActualizarEmpleado(EntidadEmpleados Entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(Entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPActualizarEmpleado");
                Comando.Parameters.AddWithValue("@_IdRegistro", Entidad.IdEmpleado);
                Comando.Parameters.AddWithValue("@_TxtNit", Entidad.TxtNit);
                Comando.Parameters.AddWithValue("@_TxtDpi", Entidad.TxtDpi);
                Comando.Parameters.AddWithValue("@_TxtNombres", Entidad.TxtNombres);
                Comando.Parameters.AddWithValue("@_TxtApellidos", Entidad.TxtApellidos);
                Comando.Parameters.AddWithValue("@_IdPuesto", Entidad.IdPuesto);
                Comando.Parameters.AddWithValue("@_IdEspecialidad", Entidad.IdEspecialidad);
                Comando.Parameters.AddWithValue("@_IdServicio", Entidad.IdServicio);
                Comando.Parameters.AddWithValue("@_IdRenglon", Entidad.IdRenglon);
                Comando.Parameters.AddWithValue("@_IdInstitucion", Entidad.idInstitucion);

                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable ObtenerEmpleados(EntidadEmpleados entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPObtenerEmpleados");
                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable ObtenerDatosEmpleado(EntidadEmpleados entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPObtenerDatosEmpleado");
                Comando.Parameters.AddWithValue("@_IdRegistro", entidad.IdEmpleado);

                DT = Conexion.ejecutarComandoSelect(Comando);
                DT = Funciones.AgregarEstadoToken(DT, Estado.ToString());
            }
            else
            {
                DT = Funciones.AgregarEstadoToken(DT, "0");
            }

            return DT;
        }

        public static DataTable EliminarEmpleado(EntidadEmpleados entidad)
        {
            Estado = Funciones.ObtenerEstadoToken(entidad.txtToken);
            DT.Clear();

            // 0 expirado, 1 vigente
            if (Estado == 1)
            {
                SqlCommand Comando = Conexion.crearComandoProc("RRHH.SPEliminarEmpleado");
                Comando.Parameters.AddWithValue("@_IdRegistro", entidad.IdEmpleado);

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
