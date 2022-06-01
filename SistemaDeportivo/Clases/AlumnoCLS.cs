using System.ComponentModel.DataAnnotations;

namespace SistemaDeportivo.Clases
{
    public class AlumnoCLS
    {
        [Required(ErrorMessage = "Se requiere un usuario valido")]
        [MaxLength(10, ErrorMessage = "El limite de caracteres es 30")]
        [MinLength(10, ErrorMessage = "El usuario debe tener 10 caracteres")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Se requiere un usuario valido")]
        [MaxLength(30, ErrorMessage = "El limite de caracteres es 30")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener minimo 8 caracteres")]
        public string Contraseña { get; set; }
        [Required(ErrorMessage = "Se requiere un nombre valido")]
        [MaxLength(30, ErrorMessage = "El limite de caracteres es 30")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Se requiere un apellido paterno valido")]
        [MaxLength(30, ErrorMessage = "El limite de caracteres es 30")]
        public string ApellidoPat { get; set; }
        [Required(ErrorMessage = "Se requiere un apellido materno valido")]
        [MaxLength(30, ErrorMessage = "El limite de caracteres es 30")]
        public string ApellidoMat { get; set; }
        [Required(ErrorMessage = "Coloca una edad entre 15 y 22 años")]        
        [Range(15,22,ErrorMessage ="Coloca una edad valida")]
        public decimal Edad { get; set; }
        [Required(ErrorMessage = "Selecciona un Género")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Se requiere un Correo valido")]
        [EmailAddress(ErrorMessage ="Coloca un correo valido")]
        public string Correo { get; set; }
        [Required(ErrorMessage ="Coloca un número de celular")]
        [Phone(ErrorMessage = "Coloca un número de celular valido")]
        public string Celular { get; set; }
        [Display(Name = "Deporte")]
        [Required(ErrorMessage = "Selecciona un Deporte")]
        public string IdDeporte { get; set; }
    }
}
