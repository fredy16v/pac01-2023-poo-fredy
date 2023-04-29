using GestionRecursosHumanos.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace GestionRecursosHumanos.Models
{
	public class Empleado
	{
		public int Id { get; set; }
		public int UsuarioId { get; set; }
		//[Display(Name = "Nombre")]
		[Required(ErrorMessage = "El {0} es requerido.")]
		[PrimeraLetraMayuscula]
		public string Nombre { get; set; }

		[Display(Name = "Fecha de Nacimiento")]
		[Required(ErrorMessage = "La {0} es requerida.")]
		public DateTime FechaNacimiento { get; set; }
		public string Genero { get; set; }

		[Required(ErrorMessage = "El {0} es requerido")]
		[EmailAddress(ErrorMessage = "El {0} debe ser un correo electronico")]
		public string Email { get; set; }

		[Required(ErrorMessage = "El {0} es requerido.")]
		public int Telefono { get; set; }

		[Display(Name = "Fecha de Ingreso")]
		[Required(ErrorMessage = "La {0} es requerida.")]
		public DateTime FechaIngreso { get; set; }

		[Required(ErrorMessage = "El {0} es requerido.")]
		public int Salario { get; set; }

		//[Required(ErrorMessage = "El {0} es requerido.")]
		public string Departamento { get; set; }
		[Display(Name = "Departamento")]
		public int DepartamentoId { get; set; }
		[Display(Name = "Cargo")]
		//[Required(ErrorMessage = "El {0} es requerido.")]
		public int CargoId { get; set; }
		public string Cargo { get; set; }

		public string Estado { get; set; }

		public string? Descripcion { get; set; }
	}
}
