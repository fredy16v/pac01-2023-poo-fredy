using GestionRecursosHumanos.Validaciones;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GestionRecursosHumanos.Models
{
	public class Cargo
	{
		public int Id { get; set; }
		[Display(Name = "Nombre")]
		[Required(ErrorMessage = "El {0} es requerido.")]
		[PrimeraLetraMayuscula]
		[Remote(action: "VerificarExisteCargo", "Cargos")]
		public string Nombre { get; set; }
		public int UsuarioId { get; set; }
		//public int Orden { get; set; }
		[Display(Name = "Codigo")]
		[Required(ErrorMessage = "El {0} es requerido.")]
		public string Codigo { get; set; }
		public string? Descripcion { get; set; }
	}
}
