using Dapper;
using GestionRecursosHumanos.Models;
using Microsoft.Data.SqlClient;

namespace GestionRecursosHumanos.Servicios
{
	public class RepositorioDepartamentos : IRepositorioDepartamentos
	{
		private readonly IConfiguration configuration;
		private readonly string connectionString;

		public RepositorioDepartamentos(IConfiguration configuration)
		{
			this.configuration = configuration;
			connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		public async Task<IEnumerable<Departamento>> Obtener(int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			return await connection.QueryAsync<Departamento>
				(@"SELECT Id, UsuarioId, SalarioId, Nombre, Codigo, Descripcion
				FROM Departamentos
				WHERE UsuarioId = @UsuarioId", new { usuarioId });
		}

		public async Task<Departamento> Crear(Departamento departamento)
		{
			using var connection = new SqlConnection(connectionString);
			await connection.QuerySingleAsync<int>
				($@"INSERT INTO Departamentos
                (Nombre, Codigo, Descripcion, SalarioId)
                VALUES
                (@Nombre, @Codigo, @Descripcion, @SalarioId);
                SELECT SCOPE_IDENTITY();",
				departamento);

			return departamento;
		}

		public async Task<Departamento> ObtenerPorId(int id, int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			return await connection.QueryFirstOrDefaultAsync<Departamento>
				(@"SELECT Id, Nombre, Codigo, UsuarioId, SalarioId, Descripcion
				FROM Departamentos
				WHERE Id = @Id AND UsuarioId = @UsuarioId", new { id, usuarioId });
		}
	}
}
