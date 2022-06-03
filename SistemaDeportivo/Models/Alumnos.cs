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
        }
        [Key]
        [Display(Name = "#")]
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidoMat { get; set; }
        public decimal Edad { get; set; }
        [Display(Name = "Género")]
        public string Sexo { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public int IdUsuario { get; set; }
        public int? IdDeporte { get; set; }

        public virtual Deporte IdDeporteNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Credencial> Credencial { get; set; }
    }
}
