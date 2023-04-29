using GestionRecursosHumanos.Models;

namespace GestionRecursosHumanos.Servicios
{
	public interface IRepositorioSalarios
	{
		Task Actualizar(SalarioCreacionViewModel modelo);
		Task Borrar(int id);
		Task Crear(Salario salario);
		//Task Editar(EditarSalarioViewModel salario);
		Task<bool> Existe(string nombre, int usuarioId);
		Task<IEnumerable<Salario>> Obtener(int usuarioId);
		Task<Salario> ObtenerPorId(int id, int usuarioId);
	}
}