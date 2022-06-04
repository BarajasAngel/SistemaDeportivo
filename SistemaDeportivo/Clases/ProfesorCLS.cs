using System.ComponentModel.DataAnnotations;

namespace SistemaDeportivo.Clases
{
    public class ProfesorCLS
    {
        [Display(Name = "#")]
        public int IdProfesor { get; set; }
        public string Usuario { get; set; }
        [Display(Name = "Nombre completo")]
        [Required(ErrorMessage = "Ingresa un nombre")]
        [MaxLength(100, ErrorMessage = "El limite de caracteres es de 100")]
        public string Nombre { get; set; }
        [Display(Name = "Deporte")]
        [Required(ErrorMessage = "Ingresa un Deporte Valido")]
        public string NombreDeporte { get; set; }
        [Required(ErrorMessage = "Ingresa un horario valido")]        
        public string Lunes { get; set; }
        [Display(Name = "Martes")]
        [Required(ErrorMessage = "Ingresa un horario valido")]
        public string Marte { get; set; }
        [Required(ErrorMessage = "Ingresa un horario valido")]
        public string Miercoles { get; set; }
        [Required(ErrorMessage = "Ingresa un horario valido")]
        public string Jueves { get; set; }
        [Required(ErrorMessage = "Ingresa un horario valido")]
        public string Viernes { get; set; }
    }
}
