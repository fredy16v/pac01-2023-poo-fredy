using GestionRecursosHumanos.Models;

namespace GestionRecursosHumanos.Servicios
{
	public interface IRepositorioEmpleados
	{
		Task Actualizar(EmpleadoCreacionViewModel modelo);
		Task Crear(Empleado empleado);
		Task<IEnumerable<Empleado>> ObtenerEmpleados(int usuarioId);
		Task<Empleado> ObtenerPorId(int id, int usuarioId);
	}
}