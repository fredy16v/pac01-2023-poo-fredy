using Dapper;
using GestionRecursosHumanos.Models;
using Microsoft.Data.SqlClient;

namespace GestionRecursosHumanos.Servicios
{
	public class RepositorioEmpleados : IRepositorioEmpleados
	{
		private readonly IConfiguration configuration;
		private readonly string connectionString;

		public RepositorioEmpleados(IConfiguration configuration)
		{
			this.configuration = configuration;
			connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		public async Task<IEnumerable<Empleado>> Obtener(int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			return await connection.QueryAsync<Empleado>
				(@"SELECT Id, Nombre, FechaNacimiento, Genero, Email, Telefono, Departamento
				FROM Empleados
				WHERE UsuarioId = @UsuarioId", new { usuarioId });
		}

		public async Task<Empleado> Crear(Empleado empleado)
		{
			using var connection = new SqlConnection(connectionString);
			await connection.QuerySingleAsync<int>
				($@"INSERT INTO Empleados
                (Nombre, UsuarioId, Codigo, Descripcion)
                VALUES
                (@Nombre, @UsuarioId, @Codigo, @Descripcion);
                SELECT SCOPE_IDENTITY();",
				empleado);

			return empleado;
		}
	}
}
