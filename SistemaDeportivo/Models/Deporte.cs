using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class Deporte
    {
        public Deporte()
        {
            Alumnos = new HashSet<Alumnos>();
            Profesores = new HashSet<Profesores>();
        }
        [Key]
        public int IdDeporte { get; set; }
        [Display(Name = "Deporte")]
        public string NombreDeporte { get; set; }        
        public int IdHorario { get; set; }
        public int Cupo { get; set; }

        public virtual Horario IdHorarioNavigation { get; set; }
        public virtual ICollection<Alumnos> Alumnos { get; set; }
        public virtual ICollection<Profesores> Profesores { get; set; }
    }
}
