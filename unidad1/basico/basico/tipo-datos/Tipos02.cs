using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basico.tipo_datos
{
    internal class Tipos02
    {
        public Tipos02()
        {
            //Ejemplo del string

            Console.WriteLine("Ingrese su nombre: ");
            String nombre = Console.ReadLine();

            //ejemplo con un volor entero o int

            Console.WriteLine("Ingrese su edad: ");
            int edad = int.Parse(Console.ReadLine());

            //ejeplo con boolean

            Console.WriteLine("Ingrese su genero: ");
            bool genero = bool.Parse(Console.ReadLine());

            Console.WriteLine("El nombre ingresado es: " + nombre);
            Console.WriteLine("Su edad es: " + edad);
            Console.WriteLine("El genero ingresado es: " + genero);
        }
    }
}
