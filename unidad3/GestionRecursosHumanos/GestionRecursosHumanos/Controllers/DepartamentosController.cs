using GestionRecursosHumanos.Models;
using GestionRecursosHumanos.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestionRecursosHumanos.Controllers
{
	public class DepartamentosController : Controller
	{
		private readonly IRepositorioDepartamentos repositorioDepartamentos;
		private readonly IServicioUsuarios servicioUsuarios;

		public DepartamentosController(IRepositorioDepartamentos repositorioDepartamentos, IServicioUsuarios servicioUsuarios)
		{
			this.repositorioDepartamentos = repositorioDepartamentos;
			this.servicioUsuarios = servicioUsuarios;
		}
		public async Task<IActionResult> Index()
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var departamentos = await repositorioDepartamentos.Obtener(usuarioId);

			return View(departamentos);
		}

		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Crear(Departamento departamento)
		{
			//if (!ModelState.IsValid)
			//{
			//	return View(departamento);
			//}

			departamento.UsuarioId = servicioUsuarios.ObtenerUsuarioId();//porque no puede ser null
																  //cargo.Orden = 0;//porque no puede ser null

			//var yaExisteCargo = await repositorioCargos.Existe(cargo.Nombre, cargo.UsuarioId);

			//if (yaExisteCargo)
			//{
			//	ModelState.AddModelError(nameof(cargo.Nombre), $"El nombre {cargo.Nombre} ya existe");
			//	return View(cargo);
			//}

			await repositorioDepartamentos.Crear(departamento);

			return RedirectToAction("Index");
		}
	}
}
