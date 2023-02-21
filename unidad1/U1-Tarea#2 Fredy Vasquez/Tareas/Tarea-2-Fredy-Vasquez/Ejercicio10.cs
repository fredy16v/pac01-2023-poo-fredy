using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Tarea_2_Fredy_Vasquez
{
    internal class Ejercicio10
    {
        int control = 0, suma = 0, numero = 2;
        public Ejercicio10()
        {
            while (control != 50)
            {
                if ((numero % 2) == 0)
                {
                    suma = suma + numero;
                    control++;
                }
                numero++;
            }
            Console.WriteLine("La suma de los numero pares del 1 al 100 es " + suma);
        }
    }
}
