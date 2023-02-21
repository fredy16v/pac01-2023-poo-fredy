using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Tarea_2_Fredy_Vasquez
{
    internal class Ejercicio2
    {
        public Ejercicio2()
        {
            Console.WriteLine("Ingrese el primer numero: ");
            int n1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo numero: ");
            int n2 = int.Parse(Console.ReadLine());

            if (n1 > n2)
            {
                Console.WriteLine("El numero mayor es: " + n1);
            }
            if (n1 < n2)
            {
                Console.WriteLine("El numero mayor es: " + n2);
            }
            if (n1 == n2)
            {
                Console.WriteLine("El numero " + n1 + " es igual al numero " + n2);
            }
        }
    }
}
