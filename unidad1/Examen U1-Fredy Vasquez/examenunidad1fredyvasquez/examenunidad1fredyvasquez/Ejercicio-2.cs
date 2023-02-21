using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenunidad1fredyvasquez
{
    internal class Ejercicio_2
    {
        public Ejercicio_2()
        {
            Console.WriteLine("Ingrese el tamaño de su arreglo");
            int tamaño = int.Parse(Console.ReadLine());

            int[] arreglo = new int[tamaño];
            int contador = 0;

            for (int i = 0; i < arreglo.Length; i++)
            {
                Console.WriteLine("Ingrese un numero para su arreglo:");
                arreglo[i] = int.Parse(Console.ReadLine());
            }
            //Console.WriteLine(arreglo.Contains());
            for (int i = 0; i < arreglo.Length; i++)
            {

                //Console.WriteLine(arreglo[i]);
            }
        }
    }
}
