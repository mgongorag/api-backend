using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadEmpleados : EntidadTokens
    {
        public int IdEmpleado { get; set; }
        public string TxtNit { get; set; }
        public string TxtDpi { get; set; }
        public string TxtNombres { get; set; }
        public string TxtApellidos { get; set; }
        public int IdPuesto { get; set; }
        public int IdEspecialidad { get; set; }
        public int IdServicio { get; set; }
        public int IdRenglon { get; set; }
    }

    public class EntidadEspecialidades : EntidadTokens
    {
        public int IdEspecialidad { get; set; }
        public string TxtEspecialidad { get; set; }
    }

    public class EntidadPuestos : EntidadTokens
    {
        public int IdPuesto { get; set; }
        public string TxtPuesto { get; set; }
    }

    public class EntidadRenglones : EntidadTokens
    {
        public int IdRenglon { get; set; }
        public string TxtRenglon { get; set; }
    }

    public class EntidadServicios : EntidadTokens
    {
        public int IdServicio { get; set; }
        public string TxtServicio { get; set; }
    }
}
