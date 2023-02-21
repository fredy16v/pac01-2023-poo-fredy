using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace examenunidad1fredyvasquez
{
    internal class Ejercicio_3
    {
        Random random = new Random();
        public Ejercicio_3()
        {
            Console.WriteLine("Ingrese el numero de filas que desea en su matriz:");
            int filas = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el numero de columnas que desea en su matriz:");
            int columnas = int.Parse(Console.ReadLine());

            int filasT = filas + 1;
            int columnasT = columnas + 1;

            int[,] matriz = new int[filasT, columnasT];

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    matriz[i, j] = random.Next(1,100);
                    Console.WriteLine(matriz[i, j]);

                    //sumFilas+= matriz[i, j];
                    //sumColumnas+= matriz[i, j];

                }
            }

            for (int i = 0; i < 3; i++)
            {
                int suma = 0, sumaRow = 0;

                for (int j = 0; j < 3; j++)
                {
                    int col1 = matriz[0, i];
                    int col2 = matriz[1, i];
                    int col3 = matriz[2, i];

                    int row1 = matriz[i, 0];
                    int row2 = matriz[i, 1];
                    int row3 = matriz[i, 2];

                    suma = col1 + col2 + col3;
                    sumaRow = row1 + row2 + row3;
                }

                matriz[3, i] = suma;
                matriz[i, 3] = sumaRow;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(matriz[i, j]);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}
