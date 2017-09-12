using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Задание4
{
    class Program
    {
        const int SIZE_ARRAY = 1000;

        static void Print(int[] a, int n)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write(a[i]);
            }

            Console.WriteLine();
        }

        static void FormNum(int[] a, out int n)
        {
            Console.Write("Введите число: ");
            string str = Console.ReadLine();

            n = str.Length;

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(str[n - 1 - i].ToString());//записываем число в массив в обратном порядке для сложения
            }
        }

        static void Umn(int n1, int n2, int[] a, int[] b, int[] c, out int length)
        {

            length = n1 + n2 + 1;

            for (int ix = 0; ix < n1; ix++)
                for (int jx = 0; jx < n2; jx++)
                    c[ix + jx] += a[ix] * b[jx];

            for (int ix = 0; ix < length; ix++)
            {
                c[ix + 1] += c[ix] / 10;//перенос разряда
                c[ix] %= 10;
            }

            while (c[length] == 0)
                length--;
        }

        //вычитание единицы из числа
        static void DiffOne(int[] a, ref int size)
        {
            int i = 0;

            if (a[0] != 0) //если есть что вычитать из младшего разряда
            {
                a[0] = a[0] - 1;
            }
            else //нужно взять из старшего, если число = 100 то нужно все нули заменить на 9 а где не нули вычесть 1
            {
                for (i = 0; i < size; i++)
                {
                    if (a[i] == 0)
                    {
                        a[i] = 9;
                    }
                    else
                    {
                        a[i] = a[i] - 1;
                        break;
                    }
                }
            }

            //если было число 10 (размер 2) и стало число 9, нужно размер уменьшить на 1
            if (a[size - 1] == 0)
                size -= 1;
        }

        static int[] CalcFactor(out int size)
        {
            size = 3;

            int[] num1 = new int[SIZE_ARRAY];
            //FormNum(num1, out size);
            num1[2] = 1;

            int len = size;

            int[] num2 = new int[SIZE_ARRAY];

            //переписываем исходное число в новый массив, так как дальше исходное число уменьшится на 1 (метод DiffOne)
            for (int i = 0; i < SIZE_ARRAY; i++)
            {
                num2[i] = num1[i];
            }

            do
            {
                DiffOne(num1, ref len); //вычитание единицы из числа

                if (len != 0)
                {
                    int[] c = new int[SIZE_ARRAY]; //тут будет храниться результат произведения
                    int len1;
                    Umn(len, size, num1, num2, c, out len1);

                    for (int i = 0; i < SIZE_ARRAY; i++) //перепишем результат произведения в другой массив
                    {
                        num2[i] = c[i];
                    }

                    size = len1 + 1;
                }
            }
            while (len != 0);

            return num2;
        }

        static int[] CalcStepen(out int size)
        {
            int size1 = 1;
            int size2 = 1;

            int[] num1 = new int[SIZE_ARRAY];
            num1[0] = 2;

            int[] num2 = new int[SIZE_ARRAY];
            num2[0] = 2; //то на что умножаем

            for (int i = 0; i < 99; i++)
            {
                int[] c = new int[SIZE_ARRAY]; //тут будет храниться результат произведения
                int len1;
                Umn(size1, size2, num1, num2, c, out len1);

                for (int t = 0; t < SIZE_ARRAY; t++) //перепишем результат произведения в другой массив
                {
                    num1[t] = c[t];
                }

                size1 = len1 + 1;
            }

            size = size1;

            return num1;
        }

        static void Sum(int size_a, int size_b, int[] a, int[] b)
        {
            int length;

            length = Math.Max(size_a, size_b) + 1;

            for (int ix = 0; ix < length; ix++)
            {
                b[ix] += a[ix]; // суммируем последние разряды чисел
                b[ix + 1] += (b[ix] / 10); // если есть разряд для переноса, переносим его в следующий разряд
                b[ix] %= 10; // если есть разряд для переноса он отсекается
            }

            if (b[length - 1] == 0)
                length--;

            Print(b, length);
        }

        static void difference(int[] a, int[] b, int length, int k)
        {
            int[] c = new int[SIZE_ARRAY];

            int i;
            int temp;
            int carry = 0;//перенос

            for (i = 0; i < length; i++)
            {
                temp = a[i] - b[i] + carry;
                if (temp < 0)
                {
                    c[i] = temp + 10;
                    carry = -1;
                }
                else
                {
                    c[i] = temp;
                    carry = 0;
                }
            }

            i = length - 1;

            while ((i > 0) && (c[i] == 0))
                i--;

            if (k == 2)
                c[i] *= -1;//если из меньш больш вычитаем

            Print(c, i + 1);
        }

        static void Diff(int size_a, int size_b, int[] a, int[] b)
        {
            int k = 3; // если к == 3, значит числа одинаковой длинны
            int length = size_a;
            if (size_a > size_b)
            {
                length = size_a;
                k = 1; // если к == 1, значит первое число длиннее второго
            }
            else if (size_b > size_a)
            {
                length = size_b;
                k = 2; // если к == 2, значит второе число длиннее первого
            }
            else // если числа одинаковой длинны, то необходимо сравнить их веса
                for (int ix = length - 1; ix > 0;) // поразрядное сравнение весов чисел
                {
                    if (a[ix] > b[ix]) // если разряд первого числа больше
                    {
                        k = 1; // значит первое число длиннее второго
                        break; // выход из цикла for
                    }

                    if (b[ix] > a[ix]) // если разряд второго числа больше
                    {
                        k = 2; // значит второе число длиннее первого
                        break; // выход из цикла for
                    }
                }

            if (k == 1) difference(a, b, length, k);
            if (k == 2) difference(b, a, length, k);
            if (k == 3)
                Console.WriteLine(0);
        }

        static void Main(string[] args)
        {
            //int[] num1 = new int[SIZE_ARRAY];
            //int n1;
            //FormNum(num1, out n1);

            //int[] num2 = new int[SIZE_ARRAY];
            //int n2;
            //FormNum(num2, out n2);

            //int[] c = new int[SIZE_ARRAY];
            //int l;

            //Umn(n1, n2, num1, num2, c, out l);

            int size1;

            int[] num1 = CalcFactor(out size1);

            Console.WriteLine("Факториал");

            Print(num1, size1);

            int size2;

            int[] num2 = CalcStepen(out size2);

            Console.WriteLine("Степень");

            Print(num2, size2);

            Console.WriteLine("Сумма");

            //Diff(size1, size2, num1, num2);
            Sum(size1, size2, num1, num2);

            Console.ReadLine();
        }
    }
}
