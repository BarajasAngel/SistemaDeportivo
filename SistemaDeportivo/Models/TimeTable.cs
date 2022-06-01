using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class TimeTable
    {
        public TimeTable()
        {
            Sport = new HashSet<Sport>();
        }

        public int IdHorario { get; set; }
        public TimeSpan? Lunes { get; set; }
        public TimeSpan? Marte { get; set; }
        public TimeSpan? Miercoles { get; set; }
        public TimeSpan? Jueves { get; set; }
        public TimeSpan? Viernes { get; set; }

        public virtual ICollection<Sport> Sport { get; set; }
    }
}
