using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Datos
{
    public class Funciones
    {
        private static DataTable dt = new DataTable();
        public static string lblStatus = "";
        private static string codigoSeguridad = "j@3!";

        public static string SeguridadSHA521(string pass)
        {
            System.Security.Cryptography.SHA512Managed HashhTool = new System.Security.Cryptography.SHA512Managed();
            Byte[] HashByte = Encoding.UTF8.GetBytes(string.Concat(pass, codigoSeguridad));
            Byte[] EncryptedByte = HashhTool.ComputeHash(HashByte);
            HashhTool.Clear();

            return Convert.ToBase64String(EncryptedByte);
        }

        public static string generarTokenSesion()
        {
            Random Rnd = new Random();
            int Aleatorio = Rnd.Next(1, 99999);

            string Hora = DateTime.Now.ToString("hh:mm:ss");
            string Fecha = DateTime.Now.ToString("dd/MM/yyyy");

            string TxtToken = SeguridadSHA521(Fecha + Hora + Aleatorio);

            TxtToken = Regex.Replace(TxtToken, @"[^0-9A-Za-z]", "", RegexOptions.None);

            return TxtToken;
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

        public static DataTable AgregarEstadoToken(DataTable dt, string Estado)
        {
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("EstatoToken", typeof(string), Estado).SetOrdinal(0);
            }
            else
            {
                dt.Reset();
                dt.Clear();

                try
                {
                    DataColumn Col = new DataColumn();
                    Col.ColumnName = "EstadoToken";
                    dt.Columns.Add(Col);

                    DataRow Fila = dt.NewRow();
                    Fila["EstadoToken"] = Estado;
                    dt.Rows.Add(Fila);
                }
                catch
                {
                    DataRow Fila = dt.NewRow();
                    Fila["EstadoToken"] = Estado;
                    dt.Rows.Add(Fila);
                }
            }
            return dt;
        }

    }
}
