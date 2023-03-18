using System.ComponentModel.DataAnnotations;

namespace Actividad_Foro_Fredy_Vasquez.Models
{
	public class NumeroTelefono
	{
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Inserte un nombre.")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Inserte un apellido.")]
		public string Apellido { get; set; }

		[Required(ErrorMessage = "Inserte un numero de telefono.")]
		public string Numero { get; set; }
		
		public string? NumeroTelFijo { get; set; }
		
		public string? NumeroTelTrabajo { get; set; }

		public string? Correo { get; set; }
	}
}
