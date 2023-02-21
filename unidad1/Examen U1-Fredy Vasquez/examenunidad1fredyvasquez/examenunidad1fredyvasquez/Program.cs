using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenunidad1fredyvasquez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String opcion;
            do
            {
                Console.WriteLine("Ingrese que ejercicio queire ver:");
                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Ejercicio_1 ejercicio_1 = new Ejercicio_1();
                        break;
                    case 2:
                        Ejercicio_2 ejercicio_2 = new Ejercicio_2();
                        break;
                    case 3:
                        Ejercicio_3 ejercicio_3 = new Ejercicio_3();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida.");
                        break;
                }
                Console.WriteLine("Desea continuar?(s/n)");
                opcion = Console.ReadLine().ToLower();
            } while (opcion != "n" && opcion != "no");

            
            
            //Ejercicio_1 ejercicio_1 = new Ejercicio_1();
            //Ejercicio_2 ejercicio_2 = new Ejercicio_2();
            //Ejercicio_3 ejercicio_3 = new Ejercicio_3();

            Console.ReadKey();
        }
    }
}
