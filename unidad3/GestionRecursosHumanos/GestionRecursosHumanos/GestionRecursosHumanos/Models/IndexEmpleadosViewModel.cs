namespace GestionRecursosHumanos.Models
{
	public class IndexEmpleadosViewModel : Empleado
	{
		public string Cargo { get; set; }
		public IEnumerable<Empleado> Empleados { get; set; }

	}
}
