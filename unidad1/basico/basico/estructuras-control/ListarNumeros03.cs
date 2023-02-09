using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basico.estructuras_control
{
    internal class ListarNumeros03
    {
        public ListarNumeros03()
        {
            int i = 1;
            Console.WriteLine("Listar numeros hasta : ");
            int limite = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i <= limite);
        }
    }
}
