using GestionRecursosHumanos.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace GestionRecursosHumanos.Models
{
	public class EditarDepartamentoViewModel : Departamento
	{
		[Required(ErrorMessage = "El campo {0} es requerido")]
		[StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "El campo {0} debe de tener entre {2} y {1} letras")]
		[PrimeraLetraMayuscula]
		public new string Nombre { get; set; }
		[Required(ErrorMessage = "El campo {0} es requerido")]
		[StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "El campo {0} debe de tener entre {2} y {1} letras")]
		public new string Codigo { get; set; }
		[StringLength(maximumLength: 50, MinimumLength = 0, ErrorMessage = "El campo {0} debe de tener entre {2} y {1} letras")]
		public new string Descripcion { get; set; }
	}
}
