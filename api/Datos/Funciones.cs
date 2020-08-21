using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Funciones
    {
        public string lblStatus = "";
        private string codigoSeguridad = "m1gU3l";

        public string SeguridadSHA521(string pass)
        {
            System.Security.Cryptography.SHA512Managed HashhTool = new System.Security.Cryptography.SHA512Managed();
            Byte[] HashByte = Encoding.UTF8.GetBytes(string.Concat(pass, codigoSeguridad));
            Byte[] EncryptedByte = HashhTool.ComputeHash(HashByte);
            HashhTool.Clear();

            return Convert.ToBase64String(EncryptedByte);
        }
        
    }
}
