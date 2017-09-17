using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание3
{
    class Program
    {

        static double InputKoord(int left, int right)//ввод координат с проверкой границ и правильности ввода 
        {
            bool ok = false;
            double number = -100;
            do
            {
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());
                    if (number >= left && number < right) ok = true;
                    else
                    {
                        Console.WriteLine("Ошибка ввода");
                        ok = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода");
                    ok = false;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка ввода");
                    ok = false;
                }
            } while (!ok);
            return number;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Введите координату x");
            double x = InputKoord(-100, 100);
            Console.WriteLine("Введите координату y");
            double y = InputKoord(-100, 100);

            if (Math.Pow(x, 2) + Math.Pow(y, 2) <= 1)
                Console.WriteLine("Точка принадлежит заданной области");
            else Console.WriteLine("Точка не принадлежит заданной области");
            Console.ReadLine();
        }

    }

}