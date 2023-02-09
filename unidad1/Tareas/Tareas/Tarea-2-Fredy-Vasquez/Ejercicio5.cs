using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Tarea_2_Fredy_Vasquez
{
    internal class Ejercicio5
    {
        public Ejercicio5() {
            Console.WriteLine("Que desea comprar: \nHamburguesa\tEnsalada\tPizza");
            String opcion = Console.ReadLine().ToLower();

            switch (opcion)
            {
                case "hamburguesa":
                    Console.WriteLine("El precio de la hamburguesa es de LPS.60");
                    break;
                case "ensalada":
                    Console.WriteLine("EL precio de la ensalada es de LPS.100");
                    break;
                case "pizza":
                    Console.WriteLine("El precio de la pizza es de LPS.199");
                    break;
                default: 
                    Console.WriteLine("Opcion invalida.");
                    break;
            }
        }
    }
}
