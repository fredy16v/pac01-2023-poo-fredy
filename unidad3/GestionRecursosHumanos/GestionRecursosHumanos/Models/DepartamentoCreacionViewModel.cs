using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionRecursosHumanos.Models
{
	public class DepartamentoCreacionViewModel : Departamento
	{
		public IEnumerable<SelectListItem> Cargos { get; set; }
	}
}
