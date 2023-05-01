using Dapper;
using GestionRecursosHumanos.Models;
using Microsoft.Data.SqlClient;

namespace GestionRecursosHumanos.Servicios
{
	public class RepositorioCapacitaciones : IRepositorioCapacitaciones
	{
		private readonly IConfiguration configuration;
		private readonly string connectionString;

		public RepositorioCapacitaciones(IConfiguration configuration)
		{
			this.configuration = configuration;
			connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		public async Task<IEnumerable<Capacitacion>> Obtener(int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);

			return await connection.QueryAsync<Capacitacion>
				(@"SELECT Id, Nombre, DepartamentoId, Fecha, Duracion, Costo, EmpleadoId, Descripcion
				FROM Capacitaciones
				WHERE UsuarioId = @UsuarioId", new { usuarioId });
		}

		public async Task<IEnumerable<Capacitacion>> ObtenerCapacitaciones(int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			return await connection.QueryAsync<Capacitacion>
				(@"SELECT
					ca.Id,
					ca.Nombre,
					ca.Fecha,
					ca.Duracion,
					ca.Costo,
					ca.Descripcion,
					de.Nombre AS Capacitacion
				FROM Capacitaciones ca
				INNER JOIN Departamentos de
				ON de.Id = em.DepartamentoId
				WHERE de.UsuarioId = @UsuarioId", new { usuarioId });
		}

		public async Task<Capacitacion> ObtenerPorId(int id, int usuarioId)
		{
			using var connection = new SqlConnection(connectionString);
			return await connection.QueryFirstOrDefaultAsync<Capacitacion>
				(@"SELECT 
					ca.Id,
					ca.Nombre,
					ca.Fecha,
					ca.Duracion,
					ca.Costo,
					ca.Descripcion
				FROM Capacitaciones AS ca
				INNER JOIN Departamentos AS de
				ON de.Id = ca.CargoId
				WHERE de.UsuarioId = @UsuarioId AND ca.Id = @Id;", new { id, usuarioId });
		}
	}
}
