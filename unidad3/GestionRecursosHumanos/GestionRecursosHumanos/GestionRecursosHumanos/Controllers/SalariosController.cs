using GestionRecursosHumanos.Models;
using GestionRecursosHumanos.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionRecursosHumanos.Controllers
{
	public class SalariosController : Controller
	{
		private readonly IRepositorioSalarios repositorioSalarios;
		private readonly IServicioUsuarios servicioUsuarios;
		private readonly IRepositorioDepartamentos repositorioDepartamentos;

		public SalariosController(IRepositorioSalarios repositorioSalarios, IServicioUsuarios servicioUsuarios, IRepositorioDepartamentos repositorioDepartamentos)
		{
			this.repositorioSalarios = repositorioSalarios;
			this.servicioUsuarios = servicioUsuarios;
			this.repositorioDepartamentos = repositorioDepartamentos;
		}

		public async Task<IActionResult> Index()
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var salariosConDepartamento = await repositorioSalarios.Obtener(usuarioId);
			var salarios = await repositorioSalarios.Obtener(usuarioId);
			var modelo = new ObtenerSalariosViewModel
			{
				Salarios = salarios.Select(salario => new SalarioDTO
				{
					Id = salario.Id,
					DepartamentoNombre = salario.Departamento,
					RangoMaximo = salario.RangoMaximo,
					RangoMinimo = salario.RangoMinimo,
				})
			};
			//var modelo = salariosConDepartamento
			//	.GroupBy(x => x.Departamento)
			//	.Select(grupo => new IndexSalariosViewModel 
			//	{
			//		Departamento = grupo.Key,
			//		Salarios = grupo.AsEnumerable()
			//	}).ToList();

			return View(modelo);
		}

		[HttpGet]
		public async Task<IActionResult> Crear()
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var modelo = new SalarioCreacionViewModel();

			modelo.Departamentos = await ObtenerDepartamentos(usuarioId);

			return View(modelo);
		}

		[HttpPost]
		public async Task<IActionResult> Crear(SalarioCreacionViewModel modelo)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();

			//if (!ModelState.IsValid)
			//{
			//	modelo.Departamentos = await ObtenerDepartamentos(usuarioId);
			//	return View(modelo);
			//}

			var departamento = await repositorioDepartamentos.ObtenerPorId(modelo.DepartamentoId, usuarioId);

			if (departamento is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			modelo.UsuarioId = usuarioId;

			await repositorioSalarios.Crear(modelo);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int id)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var salario = await repositorioSalarios.ObtenerPorId(id, usuarioId);

			if (salario is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			var modelo = new SalarioCreacionViewModel
			{
				Id = salario.Id,
				Nombre = salario.Nombre,
				DepartamentoId = salario.DepartamentoId,
				RangoMaximo = salario.RangoMaximo,
				RangoMinimo = salario.RangoMinimo,
			};

			modelo.Departamentos = await ObtenerDepartamentos(usuarioId);

			return View(modelo);

			//var editarSalario = new EditarSalarioViewModel
			//{
			//	Id = salario.Id,
			//	Nombre = salario.Nombre,
			//	RangoMaximo = salario.RangoMaximo,
			//	UsuarioId = usuarioId,
			//	RangoMinimo = salario.RangoMinimo,
			//};


			//return View(editarSalario);
		}

		[HttpPost]
		public async Task<IActionResult> Editar(SalarioCreacionViewModel modelo)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var salario = await repositorioSalarios.ObtenerPorId(modelo.Id, usuarioId);

			//if (!ModelState.IsValid)
			//{
			//	modelo.Departamentos = await ObtenerDepartamentos(usuarioId);
			//	return View(modelo);
			//}

			if (salario is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			var departamento = await repositorioDepartamentos.ObtenerPorId(modelo.DepartamentoId, usuarioId);

			if (departamento is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			await repositorioSalarios.Actualizar(modelo);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Borrar(int id)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var salario = await repositorioSalarios.ObtenerPorId(id, usuarioId);
			//var salarios = await repositorioSalarios.Obtener(usuarioId);

			if (salario is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			//return View(salario);

			//var modelo = new ObtenerSalariosViewModel
			//{
			//	Salarios = salarios.Select(salario => new SalarioDTO
			//	{
			//		Id = salario.Id,
			//		DepartamentoNombre = salario.Departamento,
			//		RangoMaximo = salario.RangoMaximo,
			//		RangoMinimo = salario.RangoMinimo,
			//	})
			//};

			var modelo = new SalarioDTO
			{
				Id = salario.Id,
				DepartamentoNombre = salario.Nombre,
				RangoMaximo = salario.RangoMaximo,
				RangoMinimo = salario.RangoMinimo,
			};

			return View(modelo);
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

		//public async Task<IActionResult> VerificarExisteSalario(string nombre)
		//{
		//	var usuarioId = servicioUsuarios.ObtenerUsuarioId();
		//	var yaExisteSalario = await repositorioSalarios.Existe(nombre, usuarioId);

		//	if (yaExisteSalario)
		//	{
		//		return Json($"EL nombre {nombre} ya existe");
		//	}

		//	return Json(true);
		//}

		private async Task<IEnumerable<SelectListItem>> ObtenerDepartamentos(int usuarioId)
		{
			var departamentos = await repositorioDepartamentos.Obtener(usuarioId);
			return departamentos.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
		}
	}
}
