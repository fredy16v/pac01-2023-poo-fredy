using Dapper;
using GestionRecursosHumanos.Models;
using Microsoft.Data.SqlClient;

namespace GestionRecursosHumanos.Servicios
{
	public class RepositorioSalarios : IRepositorioSalarios
	{
		private readonly IConfiguration configuration;
		private readonly string connectionString;

		public RepositorioSalarios(IConfiguration configuration)
		{
			this.configuration = configuration;
			connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		public async Task<IEnumerable<Salario>> Obtener(int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			return await connection.QueryAsync<Salario>
				(@"SELECT Id, Nombre, RangoMaximo, RangoMinimo
				FROM Salarios
				WHERE UsuarioId = @UsuarioId", new { usuarioId });
		}

		public async Task<Salario> Crear(Salario salario)
		{
			using var connection = new SqlConnection(connectionString);
			await connection.QuerySingleAsync<int>
				($@"INSERT INTO Salarios
                (Nombre, UsuarioId, RangoMaximo, RangoMinimo)
                VALUES
                (@Nombre, @UsuarioId, @RangoMaximo, @RangoMinimo);
                SELECT SCOPE_IDENTITY();", salario);

			return salario;
		}

		public async Task Editar(EditarSalarioViewModel salario)
		{
			using var connection = new SqlConnection(connectionString);
			await connection.ExecuteAsync
				(@"UPDATE Salarios 
				SET Nombre = @Nombre, RangoMaximo = @RangoMaximo, RangoMinimo = @RangoMinimo
				WHERE Id = @Id", salario);
		}

		public async Task Borrar(int id)
		{
			using var connection = new SqlConnection(connectionString);
			await connection.ExecuteAsync("DELETE FROM Salarios WHERE Id = @Id", new { id });
		}

		public async Task<Salario> ObtenerPorId(int id, int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			return await connection.QueryFirstOrDefaultAsync<Salario>
				(@"SELECT Id, Nombre, RangoMaximo, RangoMinimo
				FROM Salarios
				WHERE Id = @Id AND UsuarioId = @UsuarioId", new { id, usuarioId });
		}

		public async Task<bool> Existe(string nombre, int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			var existe = await connection.QueryFirstOrDefaultAsync<int>
				(@"SELECT 1
				FROM Salarios
				WHERE Nombre = @Nombre AND UsuarioId = @UsuarioId",
				new { nombre, usuarioId });

			return existe == 1;
		}
	}
}
