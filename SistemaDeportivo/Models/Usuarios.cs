using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Administrator = new HashSet<Administrator>();
            Alumnos = new HashSet<Alumnos>();
            Profesores = new HashSet<Profesores>();
        }

        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<Administrator> Administrator { get; set; }
        public virtual ICollection<Alumnos> Alumnos { get; set; }
        public virtual ICollection<Profesores> Profesores { get; set; }
    }
}
