using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Tarea_2_Fredy_Vasquez
{
    internal class Ejercicio8
    {
        public Ejercicio8()
        {
            Console.WriteLine("Ingrese el numero del cual desea calcular el factorial");
            int numero = int.Parse(Console.ReadLine());

            int resultado = 1;

            for (int i = 1; i <= numero; i++)
            {
                resultado = resultado * i;
            }
            Console.WriteLine("EL factorial de " + numero + " es " + resultado);
        }
    }
}
