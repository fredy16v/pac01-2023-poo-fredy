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
		private readonly IRepositorioDepartamentos repositorioDepartamentos;

		public EmpleadosController
			(IRepositorioEmpleados repositorioEmpleados, 
			IServicioUsuarios servicioUsuarios, 
			IRepositorioCargos repositorioCargos,
			IRepositorioDepartamentos repositorioDepartamentos)
		{
			this.repositorioEmpleados = repositorioEmpleados;
			this.servicioUsuarios = servicioUsuarios;
			this.repositorioCargos = repositorioCargos;
			this.repositorioDepartamentos = repositorioDepartamentos;
		}

		public async Task<IActionResult> Index()
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var empleadosConCargo = await repositorioEmpleados.ObtenerEmpleados(usuarioId);
			var empleados = await repositorioEmpleados.ObtenerEmpleados(usuarioId);

			var modelo = new ObtenerEmpleadosViewModel
			{
				Empleados = empleados.Select(empleado => new EmpleadoDTO 
				{
					Id = empleado.Id,
					Nombre = empleado.Nombre,
					FechaNacimiento = empleado.FechaNacimiento,
					NombreCargo = empleado.Cargo,
					NombreDepartamento = empleado.Departamento,
					Genero = empleado.Genero,
					Email = empleado.Email,
					Telefono = empleado.Telefono,
					FechaIngreso = empleado.FechaIngreso,
					Salario = empleado.Salario,
					Estado = empleado.Estado,
					Descripcion = empleado.Descripcion,
				})
			};

			//var modelo = empleadosConCargo
			//	.GroupBy(x => x.Cargo)
			//	.Select(grupo => new IndexEmpleadosViewModel
			//	{
			//		Cargo = grupo.Key,
			//		Empleados = grupo.AsEnumerable()
			//	}).ToList();

			return View(modelo);
		}

		public async Task<IActionResult> Crear()
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var modelo = new EmpleadoCreacionViewModel();

			modelo.Cargos = await ObtenerCargos(usuarioId);
			modelo.Departamentos = await ObtenerDepartamentos(usuarioId);

			return View(modelo);
		}

		[HttpPost]
		public async Task<IActionResult> Crear(EmpleadoCreacionViewModel modelo)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();

			//if (!ModelState.IsValid)
			//{
			//	modelo.Cargos = await ObtenerCargos(usuarioId);
			//	modelo.Departamentos = await ObtenerDepartamentos(usuarioId);
			//	return View(modelo);
			//}

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

		private async Task<IEnumerable<SelectListItem>> ObtenerDepartamentos(int usuarioId)
		{
			var departamentos = await repositorioDepartamentos.Obtener(usuarioId);
			return departamentos.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
		}
	}
}
