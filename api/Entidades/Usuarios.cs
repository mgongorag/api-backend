using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        public int idUsuario { get ; set; }
        public string TxtNombres { get; set; }
        public string TxtApellidos { get ; set; }
        public string TxtDireccion { get ; set; }
        public string TxtEmail { get; set; }
        public string TxtPassword { get ; set; }
        public string FechaIngreso { get ; set; }
        public int IntEstado { get ; set; }

    }
}
