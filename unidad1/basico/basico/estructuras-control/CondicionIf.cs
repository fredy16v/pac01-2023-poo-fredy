using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basico.estructuras_control
{
    internal class CondicionIf
    {
        public CondicionIf()
        {
            Console.WriteLine("Condicion");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("\nIngrese su edad:");

            int edad = int.Parse(Console.ReadLine());

            if (edad >= 18)
            {
                Console.WriteLine("Es mayor de edad.");
            }
            else
            {
                Console.WriteLine("Es menor de edad.");
            }

            if (edad >= 16 && edad <=18)
            {
                Console.WriteLine("Puede jugar en a categoria u18");
            }
            else
            {
                Console.WriteLine("No puede jugar en la categoria u18");
            }
        }
    }
}
