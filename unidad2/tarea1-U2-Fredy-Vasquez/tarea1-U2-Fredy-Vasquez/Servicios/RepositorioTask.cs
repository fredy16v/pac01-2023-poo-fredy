using tarea1_U2_Fredy_Vasquez.Interfaces;
using tarea1_U2_Fredy_Vasquez.Models;

namespace tarea1_U2_Fredy_Vasquez.Servicios
{
    public class RepositorioTask : IRepositorioTask
    {
        public List<Models.Tarea> Task { get; }

        public RepositorioTask()
        {
            Task = new List<Models.Tarea>();
        }
      
        public void ActualizarTask(Tarea task)
        {
            var tarea = Task.FirstOrDefault(tarea => tarea.Id == task.Id);

            if (tarea == null)
            {
                throw new Exception(message: "No existe ninguna tarea.");
            }
            tarea.Titulo = task.Titulo;
            tarea.Descripcion = task.Descripcion;
            tarea.FechaDeVencimiento = task.FechaDeVencimiento;
        }

        public void AgregarTask(Models.Tarea task)
        {
            task.Id = Guid.NewGuid();
            Task.Add(task);
        }

        public void EliminarTask(Guid Id)
        {
            var tarea = Task.FirstOrDefault(tarea => tarea.Id == Id);

            if (tarea == null)
            {
                throw new Exception(message: "No existe ninguna tarea.");
            }
            Task.Remove(tarea);
        }

        public Models.Tarea ObtenerPorId(Guid Id)
        {
            var tarea = Task.FirstOrDefault(tarea => tarea.Id == Id);

            if (tarea == null)
            {
                throw new Exception(message: "No existe ninguna tarea.");
            }
            return tarea;
        }

        public List<Models.Tarea> ObtenerTasks()
        {
            return Task;
        }

        
    }
}
