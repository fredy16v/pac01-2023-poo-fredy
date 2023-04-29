using GestionRecursosHumanos.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace GestionRecursosHumanos.Models
{
	public class Departamento
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "El campo {0} es requerido")]
		[StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "El campo {0} debe de tener entre {2} y {1} letras")]
		[PrimeraLetraMayuscula]
		public string Nombre { get; set; }

		//public int DepartamentosId { get; set; }
		public int UsuarioId { get; set; }
		[Required(ErrorMessage = "El campo {0} es requerido")]
		[StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "El campo {0} debe de tener entre {2} y {1} letras")]
		public string Codigo { get; set; }
		[StringLength(maximumLength: 50, MinimumLength = 0, ErrorMessage = "El campo {0} debe de tener entre {2} y {1} letras")]
		public string? Descripcion { get; set; }
	}
}
