using ExamenUnidad2FredyVasquezYJoseContreras.Intefaces;
using ExamenUnidad2FredyVasquezYJoseContreras.Models;
using System.Drawing;

namespace ExamenUnidad2FredyVasquezYJoseContreras.Services
{
	public class RepositorioAlumnos : IRepositorioAlumnos
	{
		public List<Models.Alumno> Alumnos { get; }

		public RepositorioAlumnos()
		{
			Alumnos = new List<Models.Alumno>();
		}

		public void AgregarAlumno(Models.Alumno alumno)
		{
			Alumnos.Add(alumno);
		}

        public List<Models.Alumno> ObtnerAlumnos()
        {
            return Alumnos;
        }
    }
}
