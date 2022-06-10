using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class Solicitud
    {
        public int IdSolicitud { get; set; }
        public int IdUsuario { get; set; }
        public int IdProfesor { get; set; }

        public virtual Profesores IdProfesorNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
