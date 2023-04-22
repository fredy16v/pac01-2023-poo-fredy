using GestionRecursosHumanos.Validaciones;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GestionRecursosHumanos.Models
{
	public class Cargo
	{
		[Display(Name = "Nombre")]
		[Required(ErrorMessage = "El {0} es requerido.")]
		[PrimeraLetraMayuscula]
		[Remote(action: "VerificarExisteCargo", "Cargos")]
		public int Id { get; set; }
		public string Nombre { get; set; }
		public int UsuarioId { get; set; }
		//public int Orden { get; set; }
		public string Codigo { get; set; }
		public string Descripcion { get; set; }
	}
}
