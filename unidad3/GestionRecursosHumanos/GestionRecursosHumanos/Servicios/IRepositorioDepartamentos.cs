using GestionRecursosHumanos.Models;

namespace GestionRecursosHumanos.Servicios
{
	public interface IRepositorioDepartamentos
	{
		Task<Departamento> Crear(Departamento departamento);
		Task<IEnumerable<Departamento>> Obtener(int usuarioId);
		Task<Departamento> ObtenerPorId(int id, int usuarioId);
	}
}