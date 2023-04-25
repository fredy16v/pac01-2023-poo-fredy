using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionRecursosHumanos.Models
{
	public class EmpleadoCreacionViewModel : Empleado
	{
		public IEnumerable<SelectListItem> Cargos { get; set; }
	}
}
