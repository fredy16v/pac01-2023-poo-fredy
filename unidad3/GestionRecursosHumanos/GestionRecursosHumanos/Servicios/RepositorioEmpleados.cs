using Dapper;
using GestionRecursosHumanos.Models;
using Microsoft.Data.SqlClient;

namespace GestionRecursosHumanos.Servicios
{
	public class RepositorioEmpleados : IRepositorioEmpleados
	{
		private readonly string connectionString;

		public RepositorioEmpleados(IConfiguration configuration)
		{ 
			connectionString = configuration.GetConnectionString("DefaultConnection").ToString();
		}

		public async Task Crear(Empleado empleado)
		{
			using var connection = new SqlConnection(connectionString);
			var id = await connection.QuerySingleAsync<int>
				($@"INSERT INTO Empleados
                (Nombre, FechaNacimiento, CargoId, Departamento, Genero, Email, Telefono, FechaIngreso, Salario, Estado, Descripcion)
                VALUES
                (@Nombre, @FechaNacimiento, @CargoId, @Departamento, @Genero, @Email, @Telefono, @FechaIngreso, @Salario, @Estado, @Descripcion);
                SELECT SCOPE_IDENTITY()", empleado);
		}

		public async Task<IEnumerable<Empleado>> ObtenerEmpleados(int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			return await connection.QueryAsync<Empleado>
				(@"SELECT
					em.Id,
					em.Nombre,
					em.FechaNacimiento,
					em.Genero,
					em.Email,
					em.Telefono,
					em.FechaIngreso,
					em.Salario,
					em.Departamento,
					em.Estado,
					em.Descripcion,
					ca.Nombre AS TipoCuenta
				FROM Empleados em
				INNER JOIN Cargos ca
				ON ca.Id = em.CargoId
				WHERE ca.UsuarioId = @UsuarioId", new {usuarioId});
		}

		public async Task<Empleado> ObtenerPorId(int id, int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			return await connection.QueryFirstOrDefaultAsync<Empleado>
				(@"SELECT 
					cu.Id,
					cu.Nombre,
					cu.Balance,
					cu.Descripcion,
					cu.TipoCuentaId
				FROM Empleados AS em
				INNER JOIN Cargos AS ca
				ON ca.Id = em.CargoId
				WHERE ca.UsuarioId = @UsuarioId AND em.Id = @Id;", new { id, usuarioId });
		}

		public async Task Actualizar(EmpleadoCreacionViewModel modelo)
		{
			using var connection = new SqlConnection(connectionString);

			await connection.ExecuteAsync
				(@"UPDATE Cuentas
				SET Nombre = @Nombre,
					FechaNacimiento = @FechaNacimiento,
					Genero = @Genero,
					Email = @Email,
					Telefono = @Telefono,
					Salario = @Salario,
					Departamento = @Departamento,
					Estado = @Estado,
					FechaIngreso = @FechaIngreso,
					TipoCuentaId = @TipoCuentaId
					Descripcion = @Descripcion
				WHERE Id = @Id", modelo);
		}
	}
}
