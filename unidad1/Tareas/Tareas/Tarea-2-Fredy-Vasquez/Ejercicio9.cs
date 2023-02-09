using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Tarea_2_Fredy_Vasquez
{
    internal class Ejercicio9
    {
        String opcion;
        public Ejercicio9()
        {
            while (opcion != "n" && opcion != "no")
            {
                Console.WriteLine("Si quiere continuar ingrese Si, si desea terminar ingrese No");
                opcion = Console.ReadLine().ToLower();
            }
            Console.WriteLine("Fin");
        }
    }
}
