using GestionRecursosHumanos.Validaciones;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GestionRecursosHumanos.Models
{
	public class Salario
	{
		public int Id { get; set; }

		public string Nombre { get; set; }

		public int UsuarioId { get; set; }
		public int DepartamentoId { get; set; }
		public string Departamento { get; set; }

		[Display(Name = "Rango Maximo")]
		[Required(ErrorMessage = "El {0} es requerido.")]
		public int RangoMaximo { get; set; }

		[Display(Name = "Rango Minimo")]
		[Required(ErrorMessage = "El {0} es requerido.")]
		public int RangoMinimo { get; set; }
	}
}
