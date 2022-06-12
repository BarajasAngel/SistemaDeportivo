using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class Alumnos
    {
        public Alumnos()
        {
            Credencial = new HashSet<Credencial>();
            DeporteInscrito = new HashSet<DeporteInscrito>();
            Solicitud = new HashSet<Solicitud>();
        }
        [Key]
        [Display(Name = "#")]
        public int IdAlumno { get; set; }
        [Required(ErrorMessage = "Coloque el nombre del alumno")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "Coloque el Apellido paterno del alumno")]
        public string ApellidoPat { get; set; }
        [Required(ErrorMessage = "Coloque el Apellido materno del alumno")]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoMat { get; set; }
        [Range(15, 60, ErrorMessage = "Coloca una edad Valida")]
        [Required(ErrorMessage = "Coloque la Edad del alumno")]
        public decimal Edad { get; set; }
        [Display(Name = "Género")]
        [Required(ErrorMessage = "Coloque el Genéro del alumno")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Coloque el Correo del alumno")]
        [EmailAddress(ErrorMessage = "Ingresa un correo valido")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Coloque el Celular del alumno")]
        [Phone(ErrorMessage = "Ingresa un número de celular valido")]
        public string Celular { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Credencial> Credencial { get; set; }
        public virtual ICollection<DeporteInscrito> DeporteInscrito { get; set; }
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
