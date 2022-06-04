namespace SistemaDeportivo.Clases
{
    public class General
    {
        private static string usuario;
        private static string rol;
        private static string deporte;
        private static int idAlumno;
        private static int idProfesor;

        public string Usuario { get => usuario; set => usuario = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Deporte { get => deporte; set => deporte = value; }
        public int IdAlumno { get => idAlumno; set => idAlumno = value; }
        public int IdProfesor { get => idProfesor; set => idProfesor = value; }
    }
}
