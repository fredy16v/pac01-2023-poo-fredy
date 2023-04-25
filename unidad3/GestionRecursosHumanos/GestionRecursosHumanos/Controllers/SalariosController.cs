using GestionRecursosHumanos.Models;
using GestionRecursosHumanos.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestionRecursosHumanos.Controllers
{
	public class SalariosController : Controller
	{
		private readonly IRepositorioSalarios repositorioSalarios;
		private readonly IServicioUsuarios servicioUsuarios;

		public SalariosController(IRepositorioSalarios repositorioSalarios, IServicioUsuarios servicioUsuarios)
		{
			this.repositorioSalarios = repositorioSalarios;
			this.servicioUsuarios = servicioUsuarios;
		}

		public async Task<IActionResult> Index()
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var salarios = await repositorioSalarios.Obtener(usuarioId);

			return View(salarios);
		}

		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Crear(Salario salario)
		{
			if (!ModelState.IsValid)
			{
				return View(salario);
			}

			salario.UsuarioId = servicioUsuarios.ObtenerUsuarioId();

			var yaExisteTipoCuenta = await repositorioSalarios.Existe(salario.Nombre, salario.UsuarioId);

			if (yaExisteTipoCuenta)
			{
				ModelState.AddModelError(nameof(salario.Nombre), $"El nombre {salario.Nombre} ya existe");
				return View(salario);
			}

			await repositorioSalarios.Crear(salario);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int id)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var salario = await repositorioSalarios.ObtenerPorId(id, usuarioId);

			var editarSalario = new EditarSalarioViewModel
			{
				Id = salario.Id,
				Nombre = salario.Nombre,
				RangoMaximo = salario.RangoMaximo,
				UsuarioId = usuarioId,
				RangoMinimo = salario.RangoMinimo,
			};

			if (salario is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			return View(editarSalario);
		}

		[HttpPost]
		public async Task<IActionResult> Editar(EditarSalarioViewModel editarSalario)
		{
			if (!ModelState.IsValid)
			{
				return View(editarSalario);
			}

			await repositorioSalarios.Editar(editarSalario);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Borrar(int id)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var salario = await repositorioSalarios.ObtenerPorId(id, usuarioId);

			if (salario is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			return View(salario);
		}

		[HttpPost]
		public async Task<IActionResult> BorrarConfirm(int id)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var salario = await repositorioSalarios.ObtenerPorId(id, usuarioId);

			if (salario is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			await repositorioSalarios.Borrar(id);

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> VerificarExisteSalario(string nombre)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var yaExisteSalario = await repositorioSalarios.Existe(nombre, usuarioId);

			if (yaExisteSalario)
			{
				return Json($"EL nombre {nombre} ya existe");
			}

			return Json(true);
		}
	}
}
