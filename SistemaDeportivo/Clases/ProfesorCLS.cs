using System.ComponentModel.DataAnnotations;

namespace SistemaDeportivo.Clases
{
    public class ProfesorCLS
    {        
        [Display(Name = "#")]
        public int IdProfesor { get; set; }
        public string Usuario { get; set; }
        [Display(Name = "Nombre completo")]
        public string Nombre { get; set; }                      
        [Display(Name = "Deporte")]
        public string NombreDeporte { get; set; }        
        public string Lunes { get; set; }
        [Display(Name = "Martes")]
        public string Marte { get; set; }
        public string Miercoles { get; set; }
        public string Jueves { get; set; }
        public string Viernes { get; set; }
    }
}
