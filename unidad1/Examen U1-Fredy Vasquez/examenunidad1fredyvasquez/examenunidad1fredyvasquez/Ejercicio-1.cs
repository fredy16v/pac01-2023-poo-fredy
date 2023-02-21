using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenunidad1fredyvasquez
{
    internal class Ejercicio_1
    {
            int menor, mayor;
        public Ejercicio_1()
        {
            int[,] matriz = new int[3,3];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.WriteLine("Ingrese un numero para su matriz");
                    matriz[i,j] = int.Parse(Console.ReadLine());
                    //Console.WriteLine(matriz[i,j]);
                }
            }
            menor = matriz[0,0];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (menor > matriz[i,j])
                    {
                        menor = matriz[i,j];
                    }
                }
            }
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (mayor < matriz[i, j])
                    {
                        mayor = matriz[i, j];
                    }
                }
            }
            Console.WriteLine("El numero menor es: " + menor);
            Console.WriteLine("El numero mayor es: " + mayor);

        }
    }
}
