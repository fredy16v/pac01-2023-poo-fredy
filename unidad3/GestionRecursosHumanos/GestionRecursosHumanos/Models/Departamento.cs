using GestionRecursosHumanos.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace GestionRecursosHumanos.Models
{
	public class Departamento
	{
		public int Id { get; set; }

		//[Required(ErrorMessage = "El campo {0} es requerido")]
		//[StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "El campo {0} debe de tener entre {2} y {1} letras")]
		//[PrimeraLetraMayuscula]
		public string Nombre { get; set; }

		public int SalarioId { get; set; }
		public int UsuarioId { get; set; }

		public string Codigo { get; set; }

		public string Descripcion { get; set; }
	}
}
