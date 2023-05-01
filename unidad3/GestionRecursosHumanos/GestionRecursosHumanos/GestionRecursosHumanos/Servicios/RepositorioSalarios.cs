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
				(@"SELECT sa.Id, de.Nombre AS Departamento, sa.RangoMaximo, sa.RangoMinimo
				FROM Salarios sa
				INNER JOIN Departamentos de
				ON de.Id = sa.DepartamentoId
				WHERE de.UsuarioId = @UsuarioId", new { usuarioId });
				//(@"SELECT Id, RangoMaximo, RangoMinimo
				//FROM Salarios
				//WHERE UsuarioId = @UsuarioId", new { usuarioId });
		}
		//empezamos aqui
		public async Task Crear(Salario salario)
		{
			using var connection = new SqlConnection(connectionString);
			var id = await connection.QuerySingleAsync<int>
				($@"INSERT INTO Salarios
                (DepartamentoId, UsuarioId, RangoMaximo, RangoMinimo)
                VALUES
                (@DepartamentoId, @UsuarioId, @RangoMaximo, @RangoMinimo);
                SELECT SCOPE_IDENTITY();", salario);
		}

		//public async Task Editar(EditarSalarioViewModel salario)
		//{
		//	using var connection = new SqlConnection(connectionString);
		//	await connection.ExecuteAsync
		//		(@"UPDATE Salarios 
		//		SET Nombre = @Nombre, RangoMaximo = @RangoMaximo, RangoMinimo = @RangoMinimo
		//		WHERE Id = @Id", salario);
		//}

		public async Task Borrar(int id)
		{
			using var connection = new SqlConnection(connectionString);
			await connection.ExecuteAsync("DELETE FROM Salarios WHERE Id = @Id", new { id });
		}

		public async Task<Salario> ObtenerPorId(int id, int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			return await connection.QueryFirstOrDefaultAsync<Salario>
				//(@"SELECT s.Id, s.RangoMaximo, s.RangoMinimo, d.Nombre AS DepartamentoNombre
				//FROM Salarios s
				//LEFT JOIN Departamentos d ON s.DepartamentoId = d.Id
				//WHERE s.Id = @Id AND s.UsuarioId = @UsuarioId", new { id, usuarioId });
				(@"SELECT sa.Id, sa.RangoMaximo, sa.RangoMinimo, sa.DepartamentoId, de.Nombre
				FROM Salarios AS sa
				INNER JOIN Departamentos AS de
				ON de.Id = sa.DepartamentoId
				WHERE sa.Id = @Id AND sa.UsuarioId = @UsuarioId", new { id, usuarioId });
		}

		public async Task Actualizar(SalarioCreacionViewModel modelo)
		{
			using var connection = new SqlConnection(connectionString);

			await connection.ExecuteAsync
				(@"UPDATE Salarios 
				SET RangoMaximo = @RangoMaximo, RangoMinimo = @RangoMinimo, DepartamentoId = @DepartamentoId
				WHERE Id = @Id", modelo);
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
