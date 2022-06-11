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
            DeporteInscrito = new HashSet<DeporteInscrito>();
            Profesores = new HashSet<Profesores>();
        }
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Ingresa tu usuario")]
        [StringLength(10, MinimumLength = 10,
            ErrorMessage = "Tu usuario debe contener 10 caracteres")]
        public string Usuario { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Ingresa tu contraseña")]
        [StringLength(30, MinimumLength = 8,
            ErrorMessage = "Tu contraseña debe tener entre 8 y 30 caracteres")]
        public string Contraseña { get; set; }
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<Administrator> Administrator { get; set; }
        public virtual ICollection<Alumnos> Alumnos { get; set; }
        public virtual ICollection<DeporteInscrito> DeporteInscrito { get; set; }
        public virtual ICollection<Profesores> Profesores { get; set; }
    }
}
