using Portafolio.Models;

namespace Portafolio.Interfaces
{
	public interface IServicioEmail
	{
		Task Enviar(ContactoViewModel contactoViewModel);
	}
}
