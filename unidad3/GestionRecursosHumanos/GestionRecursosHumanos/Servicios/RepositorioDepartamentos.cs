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
				(@"SELECT Id, Nombre, Codigo, Descripcion
				FROM Departamentos
				WHERE UsuarioId = @UsuarioId", new { usuarioId });
		}

		public async Task<Departamento> Crear(Departamento departamento)
		{
			using var connection = new SqlConnection(connectionString);
			await connection.QuerySingleAsync<int>
				($@"INSERT INTO Departamentos
                (Nombre, Codigo, Descripcion, UsuarioId)
                VALUES
                (@Nombre, @Codigo, @Descripcion, @UsuarioId);
                SELECT SCOPE_IDENTITY();",
				departamento);

			return departamento;
		}

		public async Task Editar(EditarDepartamentoViewModel departamento)
		{
			using var connection = new SqlConnection(connectionString);
			await connection.ExecuteAsync
				(@"UPDATE Departamentos 
				SET Nombre = @Nombre, Codigo = @Codigo, Descripcion = @Descripcion
				WHERE Id = @Id", departamento);
		}

		public async Task Borrar(int id)
		{
			using var connection = new SqlConnection(connectionString);
			await connection.ExecuteAsync("DELETE FROM Departamentos WHERE Id = @Id", new { id });
		}

		public async Task<Departamento> ObtenerPorId(int id, int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			return await connection.QueryFirstOrDefaultAsync<Departamento>
				(@"SELECT Id, Nombre, Codigo, UsuarioId, Descripcion
				FROM Departamentos
				WHERE Id = @Id AND UsuarioId = @UsuarioId", new { id, usuarioId });
		}

		public async Task<bool> Existe(string nombre, int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			var existe = await connection.QueryFirstOrDefaultAsync<int>
				(@"SELECT 1
				FROM Departamentos
				WHERE Nombre = @Nombre AND UsuarioId = @UsuarioId",
				new { nombre, usuarioId });

			return existe == 1;
		}
	}
}
