using GestionRecursosHumanos.Models;
using GestionRecursosHumanos.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionRecursosHumanos.Controllers
{
	public class EmpleadosController : Controller
	{
		private readonly IRepositorioEmpleados repositorioEmpleados;
		private readonly IServicioUsuarios servicioUsuarios;
		private readonly IRepositorioCargos repositorioCargos;

		public EmpleadosController(IRepositorioEmpleados repositorioEmpleados, IServicioUsuarios servicioUsuarios, IRepositorioCargos repositorioCargos)
		{
			this.repositorioEmpleados = repositorioEmpleados;
			this.servicioUsuarios = servicioUsuarios;
			this.repositorioCargos = repositorioCargos;
		}

		public async Task<IActionResult> Index()
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var empleadosConCargo = await repositorioEmpleados.ObtenerEmpleados(usuarioId);
			var modelo = empleadosConCargo
				.GroupBy(x => x.Cargo)
				.Select(grupo => new IndexEmpleadosViewModel
				{
					Cargo = grupo.Key,
					Empleados = grupo.AsEnumerable()
				}).ToList();

			return View(modelo);
		}

		public async Task<IActionResult> Crear()
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var modelo = new EmpleadoCreacionViewModel();

			modelo.Cargos = await ObtenerCargos(usuarioId);

			return View(modelo);
		}

		[HttpPost]
		public async Task<IActionResult> Crear(EmpleadoCreacionViewModel modelo)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();

			if (!ModelState.IsValid)
			{
				modelo.Cargos = await ObtenerCargos(usuarioId);
				return View(modelo);
			}

			var cargo = await repositorioCargos.ObtenerPorId(modelo.CargoId, usuarioId);
			if (cargo is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			await repositorioEmpleados.Crear(modelo);

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Editar(int id)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var empleado = await repositorioEmpleados.ObtenerPorId(id, usuarioId);

			if (empleado is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			var modelo = new EmpleadoCreacionViewModel
			{
				Id = empleado.Id,
				Nombre = empleado.Nombre,
				FechaNacimiento = empleado.FechaNacimiento,
				Genero = empleado.Genero,
				Email = empleado.Email,
				Telefono = empleado.Telefono,
				FechaIngreso = empleado.FechaIngreso,
				Salario = empleado.Salario,
				Departamento = empleado.Departamento,
				Estado = empleado.Estado,
				Descripcion = empleado.Descripcion,
			};

			modelo.Cargos = await ObtenerCargos(usuarioId);

			return View(modelo);
		}

		private async Task<IEnumerable<SelectListItem>> ObtenerCargos(int usuarioId)
		{
			var cargos = await repositorioCargos.Obtener(usuarioId);
			return cargos.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
		}
	}
}
