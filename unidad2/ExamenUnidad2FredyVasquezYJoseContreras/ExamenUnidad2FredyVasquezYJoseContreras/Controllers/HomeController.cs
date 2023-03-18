using ExamenUnidad2FredyVasquezYJoseContreras.Intefaces;
using ExamenUnidad2FredyVasquezYJoseContreras.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamenUnidad2FredyVasquezYJoseContreras.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IRepositorioAlumnos _repositorioAlumnos;

		public HomeController(ILogger<HomeController> logger, IRepositorioAlumnos repositorioAlumnos)
		{
			_logger = logger;
			this._repositorioAlumnos = repositorioAlumnos;
		}

		public IActionResult Index()
		{
			//var alumnos = _repositorioAlumnos.ObtnerAlumnos();

			//var alumnosViewModel = new AlumnosViewModel
			//{
			//	Alumnos = alumnos.ToList(),
			//};

			//return View(alumnosViewModel);
			return View();
		}

        public IActionResult Listado()
		{
			var alumnos = _repositorioAlumnos.ObtnerAlumnos();

			var alumnosViewModel = new AlumnosViewModel
			{
				Alumnos = alumnos.ToList(),
			};

			return View(alumnosViewModel);
		}

		public IActionResult Crear()
		{
			return View("Index");
		}

		[HttpPost]
		public IActionResult Crear (Models.Alumno alumno)
		{
			Console.WriteLine(alumno.Nombre);
			Console.WriteLine(alumno.Apellido);
			Console.WriteLine(alumno.NumeroDeCuenta);
			Console.WriteLine(alumno.Presente);
			//if (!ModelState.IsValid)
			//{
			//	return View("Index", alumno);
			//}
			//_repositorioAlumnos.AgregarAlumno(alumno);

			return RedirectToAction("Listado");
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