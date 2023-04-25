using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManejoPresupuesto.Controllers
{
	public class CuentasController : Controller
	{
		private readonly IRepositorioTiposCuenta repositorioTiposCuenta;
		private readonly IServicioUsuarios servicioUsuarios;
		private readonly IRepositorioCuentas repositorioCuentas;

		public CuentasController(IRepositorioTiposCuenta repositorioTiposCuenta, IServicioUsuarios servicioUsuarios, IRepositorioCuentas repositorioCuentas)
		{
			this.repositorioTiposCuenta = repositorioTiposCuenta;
			this.servicioUsuarios = servicioUsuarios;
			this.repositorioCuentas = repositorioCuentas;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var cuentasConTipoCuenta = await repositorioCuentas.ObtenerCuentas(usuarioId);
			var modelo = cuentasConTipoCuenta
				.GroupBy(x => x.TipoCuenta)
				.Select(grupo => new IndexCuentasViewModel 
				{ 
					TipoCuenta = grupo.Key,
					Cuentas = grupo.AsEnumerable()
				}).ToList();

			return View(modelo);
		}

		public async Task<IActionResult> Crear()
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var modelo = new CuentaCreacionViewModel();

			modelo.TiposCuenta = await ObtenerTiposCuenta(usuarioId);

			return View(modelo);
		}

		[HttpPost]
		public async Task<IActionResult> Crear(CuentaCreacionViewModel modelo)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();

			if (!ModelState.IsValid)
			{
				modelo.TiposCuenta = await ObtenerTiposCuenta(usuarioId);
				return View(modelo);
			}
			
			var tipoCuenta = await repositorioTiposCuenta.ObtenerPorId(modelo.TipoCuentaId, usuarioId);

			if (tipoCuenta is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			await repositorioCuentas.Crear(modelo);

            return RedirectToAction("Index");
		}

		public async Task<IActionResult> Editar(int id)
		{
			var usuarioId = servicioUsuarios.ObtenerUsuarioId();
			var cuenta = await repositorioCuentas.ObtenerPorId(id, usuarioId);

			if (cuenta is null)
			{
				return RedirectToAction("NoEncontrado", "Home");
			}

			var modelo = new CuentaCreacionViewModel
			{
				Id = cuenta.Id,
				Nombre = cuenta.Nombre,
				Descripcion = cuenta.Descripcion,
				Balance = cuenta.Balance,
				TipoCuentaId = cuenta.TipoCuentaId,
			};

			modelo.TiposCuenta = await ObtenerTiposCuenta(usuarioId);

			return View(modelo);
		}

		private async Task<IEnumerable<SelectListItem>> ObtenerTiposCuenta(int usuarioId)//para el combobox
		{
			var tiposCuenta = await repositorioTiposCuenta.Obtener(usuarioId);
			return tiposCuenta.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
		}
	}
}
