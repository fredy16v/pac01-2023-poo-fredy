using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Servicios
{
	public interface IRepositorioCuentas
	{
		Task Crear(Cuenta cuenta);
		Task<IEnumerable<Cuenta>> ObtenerCuentas(int usuarioId);
	}
}