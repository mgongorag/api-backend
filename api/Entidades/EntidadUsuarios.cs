namespace Entidades
{
    public class EntidadUsuarios: EntidadTokens
    {
        public int IdUsuario { get ; set; }
        public string TxtNombres { get; set; }
        public string TxtApellidos { get ; set; }
        public string TxtDireccion { get ; set; }
        public string TxtEmail { get; set; }
        public string TxtPassword { get ; set; }
        public string FechaIngreso { get ; set; }
        public int IntEstado { get ; set; }

    }
}
