using GestionRecursosHumanos.Models;

namespace GestionRecursosHumanos.Servicios
{
	public interface IRepositorioCapacitaciones
	{
		Task<IEnumerable<Capacitacion>> ObtenerCapacitaciones(int usuarioId);
		Task<Capacitacion> ObtenerPorId(int id, int usuarioId);
	}
}