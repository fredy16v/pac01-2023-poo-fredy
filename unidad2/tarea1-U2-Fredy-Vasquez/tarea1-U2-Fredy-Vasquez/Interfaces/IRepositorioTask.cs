using System.Collections;
using System.Xml.Schema;
using tarea1_U2_Fredy_Vasquez.Models;

namespace tarea1_U2_Fredy_Vasquez.Interfaces
{
    public interface IRepositorioTask
    {
        public List<Models.Tarea> Task { get;}

        public List<Models.Tarea> ObtenerTasks();
        public void AgregarTask(Models.Tarea task);
        public void EliminarTask(Guid task);
        public void ActualizarTask(Tarea task);
        public Models.Tarea ObtenerPorId(Guid Id);
    }
}
