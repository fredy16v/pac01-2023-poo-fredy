﻿using GestionRecursosHumanos.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace GestionRecursosHumanos.Models
{
	public class EditarCargoViewModel : Cargo
	{
		[Display(Name = "Nombre")]
		[Required(ErrorMessage = "El {0} es requerido.")]
		[PrimeraLetraMayuscula]
		public new string Nombre { get; set; }
		public new string Codigo { get; set; }
	}
}
