using Actividad_Foro_Fredy_Vasquez.Interfaces;
using Actividad_Foro_Fredy_Vasquez.Models;

namespace Actividad_Foro_Fredy_Vasquez.Servicios
{
	public class RepositorioAgenda : IRepositorioAgenda
	{
		public List<Models.NumeroTelefono> Agenda { get; }

		public RepositorioAgenda()
		{
			Agenda = new List<Models.NumeroTelefono>();
		}

		public void ActualizarTelefono(NumeroTelefono numero)
		{
			var contacto = Agenda.FirstOrDefault(contacto => contacto.Id == numero.Id);
			
			if (contacto == null)
			{
				throw new Exception(message: "No existe ningun contacto.");
			}
			contacto.Nombre = numero.Nombre;
			contacto.Apellido = numero.Apellido;
			contacto.Numero = numero.Numero;
			contacto.NumeroTelFijo = numero.NumeroTelFijo;
			contacto.NumeroTelTrabajo = numero.NumeroTelTrabajo;
			contacto.Correo = numero.Correo;
		}

		public void AgregarTelefono(Models.NumeroTelefono numero)
		{
			numero.Id = Guid.NewGuid();
			Agenda.Add(numero);
		}

		public void EliminarTelefono(Guid Id)
		{
			var contacto = Agenda.FirstOrDefault(contacto => contacto.Id == Id);

			if (contacto == null)
			{
				throw new Exception(message: "No existe ningun contacto.");
			}
			Agenda.Remove(contacto);
		}

		public Models.NumeroTelefono ObtenerPorId(Guid Id)
		{
			var telefono = Agenda.FirstOrDefault(telefono => telefono.Id == Id);

			if(telefono == null)
			{
				throw new Exception(message: "No existe ningun contacto.");
			}
			return telefono;
		}

		public List<Models.NumeroTelefono> ObtenerAgenda()
		{
			return Agenda;
		}
	}
}
