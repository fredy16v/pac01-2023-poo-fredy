using System.ComponentModel.DataAnnotations;

namespace tarea1_U2_Fredy_Vasquez.Models
{
    public class Tarea
    {

        public Guid Id { get; set; }
        [Required(ErrorMessage = "Inserte el titulo de la tarea.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Inserte la descripcion de la tarea.")]
        public string Descripcion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Inserte la fecha de la tarea.")]
        [DataType(DataType.Date, ErrorMessage = "Inserte la fecha de la tarea.")]
        public DateTime FechaDeVencimiento { get; set; }
    }
}
