using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionRecursosHumanos.Models
{
	public class EmpleadoCreacionViewModel : Empleado
	{
		public IEnumerable<SelectListItem> Departamentos { get; set; }
		public IEnumerable<SelectListItem> Cargos { get; set; }
	}
}
