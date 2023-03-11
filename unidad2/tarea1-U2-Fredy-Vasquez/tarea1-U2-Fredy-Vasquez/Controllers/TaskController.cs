using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tarea1_U2_Fredy_Vasquez.Interfaces;
using tarea1_U2_Fredy_Vasquez.Models;

namespace tarea1_U2_Fredy_Vasquez.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
		private readonly IRepositorioTask repositorioTask;

		public TaskController(ILogger<TaskController> logger, IRepositorioTask repositorioTask)
        {
            _logger = logger;
			this.repositorioTask = repositorioTask;
		}

        public IActionResult Index()
        {
            var task = repositorioTask.ObtenerTasks();

            var taskViewModel = new TaskViewModel
            {
                Task = task.OrderByDescending(tareaA => tareaA.FechaDeVencimiento).Reverse()
            };

            return View(taskViewModel);
        }

        public IActionResult Crear()
        {
            return View("CrearFormulario");
        }

        [HttpPost]
        public IActionResult Crear(Models.Tarea task)
        {
            repositorioTask.AgregarTask(task);

            return RedirectToAction("Index");
        }

        public IActionResult Editar(Guid Id)
        {
            var tarea = repositorioTask.ObtenerPorId(Id);

            return View("FormularioEditar", tarea);
        }

        [HttpPost]
        public IActionResult Editar(Tarea tarea)
        {
            repositorioTask.ActualizarTask(tarea);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult BorrarTarea(Guid Id)
        {
            repositorioTask.EliminarTask(Id);

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