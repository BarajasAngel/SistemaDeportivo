using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class Profesores
    {
        public Profesores()
        {
            Credencial = new HashSet<Credencial>();
            Solicitud = new HashSet<Solicitud>();
        }

        [Key]
        [Display(Name = "#")]
        public int IdProfesor { get; set; }
        [Display(Name = "Nombre completo")]
        public string Nombre { get; set; }
        public int IdUsuario { get; set; }
        public int IdDeporte { get; set; }

        public virtual Deporte IdDeporteNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Credencial> Credencial { get; set; }
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
