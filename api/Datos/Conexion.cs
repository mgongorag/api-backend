using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        private static string usuario = "sa";
        private static string password = "admin";
        private static string servidor = "GODLIKE\\SQLEXPRESS";
        private static string DB = "DBEvaluacion";

        public static string CadenaConexionSQL()
        {
            return "Persist Security Info = false; User ID = '" + usuario
                        + "'; Password = '" + password
                        + "'; Initial Catalog = '" + DB
                        + "'; Server = '" + servidor + "'";
        }

    }

    
}
