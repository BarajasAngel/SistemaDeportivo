using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Credential = new HashSet<Credential>();
        }

        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public int IdUsuario { get; set; }

        public virtual Users IdUsuarioNavigation { get; set; }
        public virtual ICollection<Credential> Credential { get; set; }
    }
}
