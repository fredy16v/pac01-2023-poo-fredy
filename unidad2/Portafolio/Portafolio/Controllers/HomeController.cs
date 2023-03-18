using Microsoft.AspNetCore.Mvc;
using Portafolio.Interfaces;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IConfiguration configuration;
		private readonly IServicioEmail servicioEmail;

		public HomeController(ILogger<HomeController> logger, 
            IRepositorioProyectos repositorioProyectos,
            IConfiguration configuration,
            IServicioEmail servicioEmail
            )
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.configuration = configuration;
			this.servicioEmail = servicioEmail;
		}

        public IActionResult Index()
        {
            /*ViewBag.Nombre = "Fredy Vasquez";*/
            /* ViewBag.Edad = 20;*/
            //var persona = new Persona()
            //{
            //    Nombre = "Fredy Vasquez",
            //    Edad = 20
            //};

            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() 
            { 
                Proyectos = proyectos
            };
            return View(modelo);
        }

        

        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            //_logger.LogCritical(contactoViewModel.Nombre);
            await servicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }

		public IActionResult Contacto()
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