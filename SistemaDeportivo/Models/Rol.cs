using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Users = new HashSet<Users>();
        }

        public int IdRol { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
