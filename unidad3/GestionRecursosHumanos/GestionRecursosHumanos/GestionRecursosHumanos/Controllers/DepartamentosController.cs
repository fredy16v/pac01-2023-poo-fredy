using GestionRecursosHumanos.Models;
using GestionRecursosHumanos.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionRecursosHumanos.Controllers
{
	public class DepartamentosController : Controller
	{
		private readonly IRepositorioDepartamentos repositorioDepartamentos;
		private readonly IServicioUsuarios servicioUsuarios;
		private readonly IRepositorioSalarios repositorioSalarios;

		public DepartamentosController(IRepositorioDepartamentos repositorioDepartamentos, IServicioUsuarios servicioUsuarios, IRepositorioSalarios repositorioSalarios)
		{
			this.repositorioDepartamentos = repositorioDepartamentos;
			this.servicioUsuarios = servicioUsuarios;
			this.repositorioSalarios = repositorioSalarios;
		}
		public async Task<IActionResult> Index()
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var departamentos = await repositorioDepartamentos.Obtener(usuarioId);

			//var modelo = departamentos
			//	.GroupBy(x => x.Salario)
			//	.Select(grupo => new IndexDepartamendosViewModel 
			//	{ 
			//		Salario = grupo.Key,
			//		Departamentos = grupo.AsEnumerable(),
			//	}).ToList();

			//return View(departamentos);
			return View(departamentos);
		}

		[HttpGet]
		public IActionResult Crear()
		{
			return View();
			//var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			//var modelo = new DepartamentoCreacionViewModel();

			//modelo.Salario = await ObtenerSalarios(usuarioId);

			//return View(modelo);
			//
			//var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			//var departamentos = await repositorioDepartamentos.ObtenerPorId(id, usuarioId);

			//var modelo = new DepartamentoCreacionViewModel
			//{
			//	Id = departamentos.Id,
			//	Nombre = departamentos.Nombre,
			//	Descripcion = departamentos.Descripcion,
			//	SalarioId = departamentos.SalarioId,
			//	Codigo= departamentos.Codigo,
			//};
			//modelo.Salario = await ObtenerDepartamentos(usuarioId);

			//return View(modelo);

			//var departamentoCrearViewModel = new DepartamentoCreacionViewModel
			//{
			//	Salario = new List<SelectListItem> { new SelectListItem { Text = "Test", Value = "1" } }
			//};

			//return View(departamentoCrearViewModel);

			//var salarios = await repositorioSalarios.ObtenerPorId(id, usuarioId);
			//var salarioItems = salarios.Select(s => new SelectListItem { Text = s.Nombre, Value = s.Id.ToString() }).ToList();

			//var departamentoCrearViewModel = new DepartamentoCreacionViewModel
			//{
			//	Salario = salarioItems
			//};

			//return View(departamentoCrearViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Crear(Departamento departamento)
		{
			if (!ModelState.IsValid)
			{
				return View(departamento);
			}

			departamento.UsuarioId = servicioUsuarios.ObtenerUsuarioId();

			var yaExisteDepartamento = await repositorioDepartamentos.Existe(departamento.Nombre, departamento.UsuarioId);

			if (yaExisteDepartamento)
			{
				ModelState.AddModelError(nameof(departamento.Nombre), $"El departamento {departamento.Nombre} ya existe");
				return View(departamento);
			}

			await repositorioDepartamentos.Crear(departamento);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int id)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var departamento = await repositorioDepartamentos.ObtenerPorId(id, usuarioId);

			var editarDepartamento = new EditarDepartamentoViewModel
			{
				Id = departamento.Id,
				Nombre = departamento.Nombre,
				UsuarioId = usuarioId,
				Codigo = departamento.Codigo,
				Descripcion = departamento.Descripcion,
			};

			if (departamento is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			return View(editarDepartamento);
		}

		[HttpPost]
		public async Task<IActionResult> Editar(EditarDepartamentoViewModel editarDepartamento)
		{
			if (!ModelState.IsValid)
			{
				return View(editarDepartamento);
			}

			await repositorioDepartamentos.Editar(editarDepartamento);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Borrar(int id)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var departamento = await repositorioDepartamentos.ObtenerPorId(id, usuarioId);

			if (departamento is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			return View(departamento);
		}

		[HttpPost]
		public async Task<IActionResult> BorrarConfirm(int id)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var departamento = await repositorioDepartamentos.ObtenerPorId(id, usuarioId);

			if (departamento is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			await repositorioDepartamentos.Borrar(id);

			return RedirectToAction("Index");
		}

		//private async Task<IEnumerable<SelectListItem>> ObtenerSalarios(int usuarioId)
		//{
		//	var salarios = await repositorioSalarios.Obtener(usuarioId);
		//	return salarios.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
		//}
	}
}
