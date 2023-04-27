namespace GestionRecursosHumanos.Models
{
	public class IndexSalariosViewModel
	{
		public string Departamento { get; set; }

		public IEnumerable<Salario> Salarios { get; set; }
	}
}
