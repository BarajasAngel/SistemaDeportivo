using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class Sport
    {
        public Sport()
        {
            Students = new HashSet<Students>();
        }

        public int IdDeporte { get; set; }
        public string NombreDeporte { get; set; }
        public int IdHorario { get; set; }

        public virtual TimeTable IdHorarioNavigation { get; set; }
        public virtual ICollection<Students> Students { get; set; }
    }
}
