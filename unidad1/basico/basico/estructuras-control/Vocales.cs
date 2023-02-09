using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace basico.estructuras_control
{
    internal class Vocales
    {
        public Vocales()
        {
            Console.WriteLine("Nombre segun la vocal");
            Console.WriteLine("------------------------------------\n");
            Console.WriteLine("Ingrese una vocal:");
            char vocal = char.Parse(Console.ReadLine());// o Console.ReadLine()[0]

            switch (vocal)
            {
                case 'a':
                    Console.WriteLine("Abel , Angel, Andrea, Ana, Antonia");
                    break;
                case 'e':
                    Console.WriteLine("Erick, Esteban, Edgardo, Erika, Esmeralda");
                    break;
                case 'i':
                    Console.WriteLine("Isis, Isabel, Isodoro, Ivan, Iris");
                    break;
                case 'o':
                    Console.WriteLine("Omar, Oscar, Orfilia, Ovidio, Octavio");
                    break;
                case 'u':
                    Console.WriteLine("Ulises, Ursula, Uriel, Ubaldo, Uriana");
                    break;
                default:
                    Console.WriteLine("La vocal no es valida.");
                    break;
            }
        }
    }
}
