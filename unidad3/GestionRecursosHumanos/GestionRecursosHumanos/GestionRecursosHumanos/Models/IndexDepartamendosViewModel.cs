namespace GestionRecursosHumanos.Models
{
	public class IndexDepartamendosViewModel
	{
		public string Salario { get; set; }

		public IEnumerable<Departamento> Departamentos { get; set; }
	}
}
