using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionRecursosHumanos.Models
{
	public class SalarioCreacionViewModel : Salario
	{
		public IEnumerable<SelectListItem> Departamentos { get; set; }
	}
}
