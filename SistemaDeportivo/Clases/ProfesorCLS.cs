using System.ComponentModel.DataAnnotations;

namespace SistemaDeportivo.Clases
{
    public class ProfesorCLS
    {
        [Display(Name = "#")]
        public int IdProfesor { get; set; }
        [Required(ErrorMessage = "Coloca un numero de empleado")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El Usuario debe contener 10 caracteres")]
        public string Usuario { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Ingresa una contraseña")]
        [Compare("ConfirmarContraseña", ErrorMessage = "Las contraseñas no coinciden")]
        public string Contraseña { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Required(ErrorMessage = "Ingresa una contraseña")]
        [Compare("Contraseña", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmarContraseña { get; set; }
        [Display(Name = "Nombre completo")]
        [Required(ErrorMessage = "Ingresa un nombre")]
        [MaxLength(100, ErrorMessage = "El limite de caracteres es de 100")]
        public string Nombre { get; set; }
        [Display(Name = "Deporte")]
        [Required(ErrorMessage = "Ingresa un Deporte Valido")]
        public string NombreDeporte { get; set; }
        [Required(ErrorMessage = "Ingresa un horario valido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Escibre un horario valido")]
        public string Lunes { get; set; }
        [Display(Name = "Martes")]
        [Required(ErrorMessage = "Ingresa un horario valido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Escibre un horario valido")]
        public string Marte { get; set; }
        [Required(ErrorMessage = "Ingresa un horario valido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Escibre un horario valido")]
        public string Miercoles { get; set; }
        [Required(ErrorMessage = "Ingresa un horario valido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Escibre un horario valido")]
        public string Jueves { get; set; }
        [Required(ErrorMessage = "Ingresa un horario valido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Escibre un horario valido")]
        public string Viernes { get; set; }
        [Display(Name = "Cupo")]
        [Range(50, 50, ErrorMessage = "El cupo tiene que ser de 50 alumno")]
        public int Cupo { get; set; }
    }
}
