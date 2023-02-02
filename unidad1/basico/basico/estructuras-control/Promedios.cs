using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basico.estructuras_control
{
    internal class Promedios
    {
        public Promedios()
        {
            Console.WriteLine("Ingrese su primer nota: ");
            int n1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su segunda nota: ");
            int n2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su tercera nota: ");
            int n3 = int.Parse(Console.ReadLine());

            
            double promedio, suma;
            suma = n1 + n2 + n3;
            promedio = suma / 3;

            Console.WriteLine("Su promedio es de: " + promedio);

            if (promedio < 70)
            {
                Console.WriteLine("Usted ha reprobado");
            }
            if (promedio >= 70 && promedio <= 80)
            {
                Console.WriteLine("Usted ha aprobado");
            }
            if (promedio > 80 && promedio <= 90)
            {
                Console.WriteLine("Tiene una promedio bueno");
            }
            if (promedio > 90)
            {
                Console.WriteLine("Tiene un promedio sobresaliente");
            }
        }
    }
}
