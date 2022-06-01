using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class Students
    {
        public Students()
        {
            Credential = new HashSet<Credential>();
        }

        public int IdAlumno { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidoMat { get; set; }
        public decimal Edad { get; set; }
        public string Sexo { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public int IdUsuario { get; set; }
        public int IdDeporte { get; set; }

        public virtual Sport IdDeporteNavigation { get; set; }
        public virtual Users IdUsuarioNavigation { get; set; }
        public virtual ICollection<Credential> Credential { get; set; }
    }
}
