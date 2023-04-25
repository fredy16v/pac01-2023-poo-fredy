using GestionRecursosHumanos.Validaciones;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GestionRecursosHumanos.Models
{
	public class Salario
	{
		public int Id { get; set; }

		[Display(Name = "Nombre")]
		[Required(ErrorMessage = "El {0} es requerido.")]
		[PrimeraLetraMayuscula]
		[Remote(action: "VerificarExisteSalario", "Salarios")]
		public string Nombre { get; set; }

		public int UsuarioId { get; set; }

		[Display(Name = "Rango Maximo")]
		[Required(ErrorMessage = "El {0} es requerido.")]
		public int RangoMaximo { get; set; }

		[Display(Name = "Rango Minimo")]
		[Required(ErrorMessage = "El {0} es requerido.")]
		public int RangoMinimo { get; set; }
	}
}
