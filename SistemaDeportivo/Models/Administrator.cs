using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class Administrator
    {
        public int IdAdministrator { get; set; }
        public string Nombre { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
