using ExamenUnidad2FredyVasquezYJoseContreras.Models;

namespace ExamenUnidad2FredyVasquezYJoseContreras.Intefaces
{
	public interface IRepositorioAlumnos
	{
		public List<Models.Alumno> ObtnerAlumnos();

		public List<Models.Alumno> Alumnos { get; }

		public void AgregarAlumno(Models.Alumno alumno);
    }
}
