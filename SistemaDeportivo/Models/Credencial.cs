using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class Credencial
    {
        public int IdCredencial { get; set; }
        public int IdProfesor { get; set; }
        public int IdAlumno { get; set; }

        public virtual Alumnos IdAlumnoNavigation { get; set; }
        public virtual Profesores IdProfesorNavigation { get; set; }
    }
}
