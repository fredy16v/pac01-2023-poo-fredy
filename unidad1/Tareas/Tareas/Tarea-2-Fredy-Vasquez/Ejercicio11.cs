using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Tarea_2_Fredy_Vasquez
{
    internal class Ejercicio11
    {
        public Ejercicio11()
        {
            int contador = 0, resultado;

            Console.WriteLine("Ingrese que tabla de multiplicar desea ver:");
            int tabla = int.Parse(Console.ReadLine());

            while (contador <= 10)
            {
                resultado = tabla * contador;

                Console.WriteLine(tabla + "x" + contador + "=" + resultado);

                contador++;
            }
        }
    }
}
