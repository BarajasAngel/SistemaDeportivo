using System.ComponentModel.DataAnnotations;

namespace SistemaDeportivo.Clases
{
	public class AlumnoCLS
	{
		[Required(ErrorMessage = "Se requiere un usuario valido")]
		[StringLength(10, MinimumLength = 10,
			ErrorMessage = "Tu usuario debe contener 10 caracteres")]
		public string Usuario { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Contraseña")]
		[Required(ErrorMessage = "Se requiere una contraseña valida")]
		[StringLength(30, MinimumLength = 8,
			ErrorMessage = "Tu contraseña debe tener entre 8 y 30 caracteres")]
		public string Contraseña { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirmar Contraseña")]
		[Required(ErrorMessage = "Se requiere una contraseña valida")]
		[StringLength(30, MinimumLength = 8,
			ErrorMessage = "Tu contraseña debe tener entre 8 y 30 caracteres")]
		[Compare("Contraseña", ErrorMessage = "Las contraseñas no coinciden")]
		public string ContraseñaConfirmar { get; set; }

		[Required(ErrorMessage = "Se requiere un nombre valido")]
		[StringLength(30, ErrorMessage = "El limite de caracteres es 30")]
		public string Nombre { get; set; }

		[Display(Name = "Apellido Paterno")]
		[Required(ErrorMessage = "Se requiere un apellido paterno valido")]
		[StringLength(30, ErrorMessage = "El limite de caracteres es 30")]
		public string ApellidoPat { get; set; }

		[Display(Name = "Apellido Materno")]
		[Required(ErrorMessage = "Se requiere un apellido materno valido")]
		[StringLength(30, ErrorMessage = "El limite de caracteres es 30")]
		public string ApellidoMat { get; set; }

		[Required(ErrorMessage = "Coloca una edad entre 15 y 22 años")]
		[Range(15, 22, ErrorMessage = "Coloca una edad valida")]
		public decimal Edad { get; set; }

		[Display(Name = "Género")]
		[Required(ErrorMessage = "Selecciona un Género")]
		public string Sexo { get; set; }

		[Required(ErrorMessage = "Se requiere un Correo valido")]
		[EmailAddress(ErrorMessage = "Coloca un correo valido")]
		public string Correo { get; set; }

		[Required(ErrorMessage = "Coloca un número de celular")]
		[Phone(ErrorMessage = "Coloca un número de celular valido")]
		public string Celular { get; set; }

	}
}
