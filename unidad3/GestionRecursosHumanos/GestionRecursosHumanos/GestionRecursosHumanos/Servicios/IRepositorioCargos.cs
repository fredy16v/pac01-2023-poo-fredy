using GestionRecursosHumanos.Models;

namespace GestionRecursosHumanos.Servicios
{
	public interface IRepositorioCargos
	{
		Task Borrar(int id);
		Task<Cargo> Crear(Cargo cargo);
		Task Editar(EditarCargoViewModel cargo);
		Task<bool> Existe(string nombre, int usuarioId);
		Task<IEnumerable<Cargo>> Obtener(int usuarioId);
		Task<Cargo> ObtenerPorId(int id, int usuarioId);
	}
}