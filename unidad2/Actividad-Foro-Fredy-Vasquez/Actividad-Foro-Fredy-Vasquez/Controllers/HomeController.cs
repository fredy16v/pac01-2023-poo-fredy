using Actividad_Foro_Fredy_Vasquez.Interfaces;
using Actividad_Foro_Fredy_Vasquez.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading;

namespace Actividad_Foro_Fredy_Vasquez.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IRepositorioAgenda _repositorioAgenda;

		public HomeController(ILogger<HomeController> logger, IRepositorioAgenda repositorioAgenda)
		{
			_logger = logger;
			this._repositorioAgenda = repositorioAgenda;
		}

		public IActionResult Index()
		{
			var contactos = _repositorioAgenda.ObtenerAgenda();

			var numeroTelefonoViewModel = new NumerosTelefonosViewModel
			{
				Telefonos = contactos.ToList(),
			};
			return View(numeroTelefonoViewModel);
		}

		public IActionResult Crear()
		{
			return View("FormularioCrear");
		}

		[HttpPost]
		public IActionResult Crear(Models.NumeroTelefono telefono)
		{
			Console.WriteLine(telefono.Numero);
			if (!ModelState.IsValid)
			{
				return View("FormularioCrear", telefono);
			}
			_repositorioAgenda.AgregarTelefono(telefono);

			return RedirectToAction("Index");
		}

		public IActionResult Editar(Guid Id)
		{
			var contacto = _repositorioAgenda.ObtenerPorId(Id);

			return View("FormularioEditar", contacto);
		}

		[HttpPost]
		public IActionResult Editar(Models.NumeroTelefono contacto)
		{
			if (!ModelState.IsValid)
			{
				return View("FormularioEditar", contacto);
			}
			_repositorioAgenda.ActualizarTelefono(contacto);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult EliminarContacto(Guid Id)
		{
			_repositorioAgenda.EliminarTelefono(Id);

			return RedirectToAction("Index");
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}