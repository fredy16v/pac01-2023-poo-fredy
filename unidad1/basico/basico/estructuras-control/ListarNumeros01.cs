using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basico.estructuras_control
{
    internal class ListarNumeros01
    {
        public ListarNumeros01()
        {
            int numero;
            do
            {
                Console.WriteLine("Listar numeros hasta : ");
                int limite = int.Parse(Console.ReadLine());

                int i = 1;

                while (i <= limite)
                {
                    Console.WriteLine(i);
                    i++;
                }
                Console.WriteLine("Escriba una 1 si desea continuar o una 0 si desea terminar.");
                numero = int.Parse(Console.ReadLine());
            } while (numero != 0);
        }
    }
}
