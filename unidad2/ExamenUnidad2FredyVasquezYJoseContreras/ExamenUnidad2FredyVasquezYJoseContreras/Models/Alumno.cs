using System.ComponentModel.DataAnnotations;

namespace ExamenUnidad2FredyVasquezYJoseContreras.Models
{
	public class Alumno
	{
		[Required(ErrorMessage = "Escriba un nombre")]
		public string Nombre { get; set; }
		[Required(ErrorMessage = "Escriba un apellido")]
		public string Apellido { get; set; }
		[Required(ErrorMessage = "Escriba un numero de cuenta")]
		public string NumeroDeCuenta { get; set; }

		public bool Presente { get; set; }

    }
}
