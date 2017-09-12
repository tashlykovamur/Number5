using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Задание5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 8;

            int[,] arr = new int[n, n];

            int a = n;

            for (int i = 0; i < n; i++)
            {
                if (i != 0)
                    a = arr[i - 1, n - 1] + n;

                for (int j = 0; j < n; j++)
                {
                    if (i % 2 == 0)
                        arr[i, j] = a--;
                    else
                        arr[i, j] = a++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}

