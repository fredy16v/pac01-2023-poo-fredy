using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basico.estructuras_control
{
    internal class ListarNumeros05
    {
        public ListarNumeros05()
        {
            Random random = new Random();
            int[] numeros = new int[10];
            int nr;

            for (int i = 0; i < 10; i++)
            {
                bool existe = false;
                do
                {
                    nr = random.Next(1, 100);
                    for (int j = 0; j < i; j++)
                    {
                        if (numeros[j] == nr)
                        {
                            existe = true;
                            break;
                        }
                    }
                } while (existe);

                numeros[i] = nr;
                Console.WriteLine(nr);
            }
        }
    }
}
