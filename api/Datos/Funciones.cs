using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Datos
{
    public class Funciones
    {
        public static string lblStatus = "";
        private static string codigoSeguridad = "m1gU3l";

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
            Random rnd = new Random();
            int aleatorio = rnd.Next(1, 9999999);

            string hora = DateTime.Now.ToString("hh:mm:ss");
            string fecha = DateTime.Now.ToString("dd/MM/yyyy");

            string txtToken = SeguridadSHA521(fecha + hora + aleatorio);

            txtToken = Regex.Replace(txtToken, @"[^0-9A-Za-z]", "", RegexOptions.None);

            return txtToken;
        }
        
    }
}
