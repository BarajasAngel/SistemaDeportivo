using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class Horario
    {
        public Horario()
        {
            Deporte = new HashSet<Deporte>();
        }
        [Key]
        public int IdHorario { get; set; }
        public string Lunes { get; set; }
        [Display(Name = "Martes")]
        public string Marte { get; set; }
        public string Miercoles { get; set; }
        public string Jueves { get; set; }
        public string Viernes { get; set; }

        public virtual ICollection<Deporte> Deporte { get; set; }
    }
}
