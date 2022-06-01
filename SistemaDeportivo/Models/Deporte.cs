using System;
using System.Collections.Generic;

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
        }

        public int IdDeporte { get; set; }
        public string NombreDeporte { get; set; }
        public int IdHorario { get; set; }

        public virtual Horario IdHorarioNavigation { get; set; }
        public virtual ICollection<Alumnos> Alumnos { get; set; }
    }
}
