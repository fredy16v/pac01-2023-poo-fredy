namespace GestionRecursosHumanos.Models
{
	public class Capacitacion
	{
		public int Id { get; set; }

		public string Nombre { get; set; }

		public int DepartamentoId { get; set; }

		public string Departamento { get; set; }

		public DateTime Fecha { get; set; }

		public int Duracion { get; set; }

		public int Costo { get; set; }

		public int EmpleadoId { get; set; }

		public string Empleado { get; set; }

		public string? Descripcion { get; set; }
	}
}
