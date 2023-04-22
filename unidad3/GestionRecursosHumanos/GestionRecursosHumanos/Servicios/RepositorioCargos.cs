using Dapper;
using GestionRecursosHumanos.Models;
using Microsoft.Data.SqlClient;

namespace GestionRecursosHumanos.Servicios
{
	public class RepositorioCargos : IRepositorioCargos
	{
		private readonly IConfiguration configuration;
		private readonly string connectionString;

		public RepositorioCargos(IConfiguration configuration)
		{
			this.configuration = configuration;
			connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		public async Task<IEnumerable<Cargo>> Obtener(int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			return await connection.QueryAsync<Cargo>
				(@"SELECT Id, Nombre, Codigo
				FROM Cargos
				WHERE UsuarioId = @UsuarioId", new { usuarioId });
		}
		public async Task<Cargo> Crear(Cargo cargo)
		{
			using var connection = new SqlConnection(connectionString);
			var id = await connection.QuerySingleAsync<int>
				($@"INSERT INTO Cargos
                (Nombre, UsuarioId, Codigo)
                VALUES
                (@Nombre, @UsuarioId, @Codigo);
                SELECT SCOPE_IDENTITY();",
				cargo);

			cargo.Id = id;

			return cargo;
		}

		public async Task Editar(EditarCargoViewModel cargo)
		{
			using var connection = new SqlConnection(connectionString);
			await connection.ExecuteAsync
				(@"UPDATE Cargos 
				SET Nombre = @Nombre, Codigo = @Codigo
				WHERE Id = @Id", cargo);
		}

		public async Task<Cargo> ObtenerPorId(int id, int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			return await connection.QueryFirstOrDefaultAsync<Cargo>
				(@"SELECT Id, Nombre, Codigo
				FROM Cargos
				WHERE Id = @Id AND UsuarioId = @UsuarioId", new { id, usuarioId });
		}


		public async Task<bool> Existe(string nombre, int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			var existe = await connection.QueryFirstOrDefaultAsync<int>
				(@"SELECT 1
				FROM Cargos
				WHERE Nombre = @Nombre AND UsuarioId = @UsuarioId",
				new { nombre, usuarioId });

			return existe == 1;
		}

		public async Task Borrar(int id)
		{
			using var connection = new SqlConnection(connectionString);
			await connection.ExecuteAsync("DELETE FROM Cargos WHERE Id = @Id", new { id });
		}
	}
}
