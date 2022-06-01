using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class Users
    {
        public Users()
        {
            Administrator = new HashSet<Administrator>();
            Students = new HashSet<Students>();
            Teacher = new HashSet<Teacher>();
        }

        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<Administrator> Administrator { get; set; }
        public virtual ICollection<Students> Students { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
