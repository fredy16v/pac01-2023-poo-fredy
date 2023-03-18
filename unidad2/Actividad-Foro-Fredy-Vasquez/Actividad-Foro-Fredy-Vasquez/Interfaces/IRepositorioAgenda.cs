using Actividad_Foro_Fredy_Vasquez.Models;

namespace Actividad_Foro_Fredy_Vasquez.Interfaces
{
	public interface IRepositorioAgenda
	{
		public List<Models.NumeroTelefono> Agenda { get; }

		public List<Models.NumeroTelefono> ObtenerAgenda();

		public void AgregarTelefono(Models.NumeroTelefono numero);

		public void EliminarTelefono(Guid numero);

		public void ActualizarTelefono(NumeroTelefono numero);

		public Models.NumeroTelefono ObtenerPorId(Guid Id);
	}
}
