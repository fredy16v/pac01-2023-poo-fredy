using GestionRecursosHumanos.Models;
using GestionRecursosHumanos.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestionRecursosHumanos.Controllers
{
	public class CargosController : Controller
	{
		private readonly IRepositorioCargos repositorioCargos;
		private readonly IServicioUsuarios servicioUsuarios;

		public CargosController(IRepositorioCargos repositorioCargos, IServicioUsuarios servicioUsuarios)
		{
			this.repositorioCargos = repositorioCargos;
			this.servicioUsuarios = servicioUsuarios;
		}

		public async Task<IActionResult> Index()
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var cargos = await repositorioCargos.Obtener(usuarioId);

			return View(cargos);
		}

		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Crear(Cargo cargo)
		{
			if (!ModelState.IsValid)
			{
				return View(cargo);
			}

			cargo.UsuarioId = servicioUsuarios.ObtenerUsuarioId();//porque no puede ser null
			//cargo.Orden = 0;//porque no puede ser null

			var yaExisteCargo = await repositorioCargos.Existe(cargo.Nombre, cargo.UsuarioId);

			if (yaExisteCargo)
			{
				ModelState.AddModelError(nameof(cargo.Nombre), $"El nombre {cargo.Nombre} ya existe");
				return View(cargo);
			}

			await repositorioCargos.Crear(cargo);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int id)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var cargo = await repositorioCargos.ObtenerPorId(id, usuarioId);

			var editarCargo = new EditarCargoViewModel
			{
				Id = cargo.Id,
				Nombre = cargo.Nombre,
				UsuarioId = usuarioId,
				Codigo = cargo.Codigo,
			};

			if (cargo is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			return View(editarCargo);
		}

		[HttpPost]
		public async Task<IActionResult> Editar(EditarCargoViewModel editarCargo)
		{
			if (!ModelState.IsValid)
			{
				return View(editarCargo);
			}

			await repositorioCargos.Editar(editarCargo);

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> VerificarExisteCargo(string nombre)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var yaExisteCargo = await repositorioCargos.Existe(nombre, usuarioId);

			if (yaExisteCargo)
			{
				return Json($"EL nombre {nombre} ya existe");
			}

			return Json(true);
		}

		[HttpGet]
		public async Task<IActionResult> Borrar(int id)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var cargo = await repositorioCargos.ObtenerPorId(id, usuarioId);

			if (cargo is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			return View(cargo);
		}

		[HttpPost]
		public async Task<IActionResult> BorrarConfirm(int id)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var cargo = await repositorioCargos.ObtenerPorId(id, usuarioId);

			if (cargo is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			await repositorioCargos.Borrar(id);

			return RedirectToAction("Index");
		}
	}
}
