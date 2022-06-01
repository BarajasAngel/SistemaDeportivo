using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Se requiere un usuario valido")]
        [MaxLength(10, ErrorMessage = "El limite de caracteres es 30")]
        [MinLength(10,ErrorMessage ="El usuario debe tener 10 caracteres")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Se requiere un usuario valido")]
        [MaxLength(30, ErrorMessage = "El limite de caracteres es 30")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener minimo 8 caracteres")]
        public string Contraseña { get; set; }
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<Administrator> Administrator { get; set; }
        public virtual ICollection<Alumnos> Alumnos { get; set; }
        public virtual ICollection<Profesores> Profesores { get; set; }
    }
}
