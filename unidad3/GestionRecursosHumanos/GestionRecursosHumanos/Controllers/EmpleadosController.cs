using GestionRecursosHumanos.Models;
using GestionRecursosHumanos.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestionRecursosHumanos.Controllers
{
	public class EmpleadosController : Controller
	{
		private readonly IRepositorioEmpleados repositorioEmpleados;
		private readonly IServicioUsuarios servicioUsuarios;

		public EmpleadosController(IRepositorioEmpleados repositorioEmpleados, IServicioUsuarios servicioUsuarios)
		{
			this.repositorioEmpleados = repositorioEmpleados;
			this.servicioUsuarios = servicioUsuarios;
		}
		public async Task<IActionResult> Index()
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var empleados = await repositorioEmpleados.Obtener(usuarioId);

			return View(empleados);
		}

		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Crear(Empleado empleado)
		{
			if (!ModelState.IsValid)
			{
				return View(empleado);
			}

			empleado.UsuarioId = servicioUsuarios.ObtenerUsuarioId();

			//var yaExisteTipoCuenta = await repositorioTiposCuenta.Existe(tipoCuenta.Nombre, tipoCuenta.UsuarioId);

			//if (yaExisteTipoCuenta)
			//{
			//	ModelState.AddModelError(nameof(tipoCuenta.Nombre), $"El nombre {tipoCuenta.Nombre} ya existe");
			//	return View(tipoCuenta);
			//}

			await repositorioEmpleados.Crear(empleado);

			return RedirectToAction("Index");
		}
	}
}
