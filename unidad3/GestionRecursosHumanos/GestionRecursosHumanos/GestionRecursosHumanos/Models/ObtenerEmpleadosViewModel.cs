namespace GestionRecursosHumanos.Models
{
	public class EmpleadoDTO
	{
		public int Id { get; set; }

		public string Nombre { get; set; }
		public DateTime FechaNacimiento { get; set; }

		public string NombreCargo { get; set; }
		public string NombreDepartamento { get; set; }

		public string Genero { get; set; }
		public string Email { get; set; }

		public int Telefono { get; set; }

		public DateTime FechaIngreso { get; set; }

		public int Salario { get; set; }

		public string Estado { get; set; }
		public string Descripcion { get; set; }
	}
	public class ObtenerEmpleadosViewModel
	{
		public IEnumerable<EmpleadoDTO> Empleados { get; set; }
	}
}
