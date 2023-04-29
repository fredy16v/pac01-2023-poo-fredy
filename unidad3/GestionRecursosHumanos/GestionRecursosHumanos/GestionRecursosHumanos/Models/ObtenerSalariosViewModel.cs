using System.Reflection.Metadata.Ecma335;

namespace GestionRecursosHumanos.Models
{
	public class SalarioDTO// solo para transportar los datos 
	{
		public int Id { get; set; }
		public string DepartamentoNombre { get; set; }
		public int RangoMaximo { get; set; }
		public int RangoMinimo { get; set; }
	}

	public class ObtenerSalariosViewModel
	{
		public IEnumerable<SalarioDTO>? Salarios { get; set; }
	}
}
