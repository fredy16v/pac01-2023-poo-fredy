using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace basico.arreglos
{
    internal class Arreglo02
    {
        public Arreglo02()
        {
            String respuesta;
            do
            {
                Random random = new Random();
                Console.WriteLine("De que tamaño quiere que sea su arreglo: ");
                int tamaño = int.Parse(Console.ReadLine());

                int[] numeros = new int[tamaño];

                for (int i = 0; i < numeros.Length; i++)
                {
                    numeros[i] = random.Next(1, 100);
                    Console.WriteLine("numero[" + i + "] = " + numeros[i]);
                }

                Console.WriteLine("Desea continuar? (s/n)");
                respuesta = Console.ReadLine().ToLower();

            } while (respuesta != "n" && respuesta != "no");
        }
    }
}
