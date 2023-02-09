using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Tarea_2_Fredy_Vasquez
{
    internal class Ejercicio3
    {
        public Ejercicio3()
        {
            Console.WriteLine("Ingrese su genero:");
            String genero = Console.ReadLine().ToLower();
            //String hombre = "h", mujer = "m";

            if (genero == "hombre" || genero == "h")
            {
                Console.WriteLine("Usted es hombre");
            }
            if (genero == "mujer" || genero == "m")
            {
                Console.WriteLine("Usted es mujer");
            }
        }
    }
}
