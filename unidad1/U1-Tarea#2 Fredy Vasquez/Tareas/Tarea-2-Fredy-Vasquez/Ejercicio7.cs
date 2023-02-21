using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Tarea_2_Fredy_Vasquez
{
    internal class Ejercicio7
    {
        public Ejercicio7()
        {
            int suma = 0;

            for (int i = 1; i <= 10; i++)
            {
                suma = suma + i;
            }
            Console.WriteLine("EL resultado de la suma es: " + suma);
        }
    }
}
