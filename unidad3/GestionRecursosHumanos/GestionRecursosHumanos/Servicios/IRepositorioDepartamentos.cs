using GestionRecursosHumanos.Models;

namespace GestionRecursosHumanos.Servicios
{
	public interface IRepositorioDepartamentos
	{
		Task Borrar(int id);
		Task<Departamento> Crear(Departamento departamento);
		Task Editar(EditarDepartamentoViewModel departamento);
		Task<bool> Existe(string nombre, int usuarioId);
		Task<IEnumerable<Departamento>> Obtener(int usuarioId);
		Task<Departamento> ObtenerPorId(int id, int usuarioId);
	}
}