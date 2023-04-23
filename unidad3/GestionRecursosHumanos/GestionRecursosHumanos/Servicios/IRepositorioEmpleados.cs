using GestionRecursosHumanos.Models;

namespace GestionRecursosHumanos.Servicios
{
	public interface IRepositorioEmpleados
	{
		Task<Empleado> Crear(Empleado empleado);
		Task<IEnumerable<Empleado>> Obtener(int usuarioId);
	}
}