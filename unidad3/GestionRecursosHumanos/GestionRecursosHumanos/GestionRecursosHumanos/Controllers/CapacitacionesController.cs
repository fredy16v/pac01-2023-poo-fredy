using GestionRecursosHumanos.Models;
using GestionRecursosHumanos.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestionRecursosHumanos.Controllers
{
	public class CapacitacionesController : Controller
	{
		private readonly IRepositorioCapacitaciones repositorioCapacitaciones;
		private readonly IRepositorioDepartamentos repositorioDepartamentos;
		private readonly IRepositorioEmpleados repositorioEmpleados;
		private readonly IServicioUsuarios servicioUsuarios;

		public CapacitacionesController
			(IRepositorioCapacitaciones repositorioCapacitaciones, IRepositorioDepartamentos repositorioDepartamentos,
			IRepositorioEmpleados repositorioEmpleados, IServicioUsuarios servicioUsuarios)
		{
			this.repositorioCapacitaciones = repositorioCapacitaciones;
			this.repositorioDepartamentos = repositorioDepartamentos;
			this.repositorioEmpleados = repositorioEmpleados;
			this.servicioUsuarios = servicioUsuarios;
		}

		public async Task<IActionResult> Index()
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			//var capacitacionesConDepartamento = await repositorioCapacitaciones.ObtenerCapacitaciones(usuarioId);
			var capacitaciones = await repositorioCapacitaciones.ObtenerCapacitaciones(usuarioId);

			var modelo = new ObtenerCapacitacionesViewModel
			{
				Capacitaciones = capacitaciones.Select(capacitacion => new CapacitacionDTO 
				{
					Id = capacitacion.Id,
					Nombre = capacitacion.Nombre,
					Fecha = capacitacion.Fecha,
					NombreDepartamento = capacitacion.Departamento,
					NombreEmpleado = capacitacion.Empleado,
					Duracion = capacitacion.Duracion,
					Costo = capacitacion.Costo,
					Descripcion = capacitacion.Descripcion,
				})
			};

			return View(modelo);
		}
	}
}
