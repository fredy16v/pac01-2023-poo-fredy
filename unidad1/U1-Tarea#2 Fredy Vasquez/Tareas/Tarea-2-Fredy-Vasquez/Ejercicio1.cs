using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Tarea_2_Fredy_Vasquez
{
    internal class Ejercicio1
    {
        public Ejercicio1()
        {
            Console.WriteLine("Ingrese un numero: ");
            int numero = int.Parse(Console.ReadLine());

            if (numero < 0)
            {
                Console.WriteLine("El nimero ingresado es negativo.");
            }
            if (numero == 0)
            {
                Console.WriteLine("El numero ingresado es 0.");
            }
            if(numero > 0)
            {
                Console.WriteLine("El numero ingresado es positivo.");
            }
        }
    }
}
