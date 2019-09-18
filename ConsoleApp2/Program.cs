﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static int Count;

        static double Delta;

        static double OurFunc(double x)
        {
            return x * x * x + 4 * x - 4;
        }

        static double FirstDerivativeOurFunc(double x)
        {
            return 3 * x * x + 4; 
        }

        static double SecondDerivativeOurFunc(double x)
        {
            return 6 * x;
        }

        static double SecondAlgoritm(double x)
        {
            var nextX = x - OurFunc(x) / FirstDerivativeOurFunc(x);
            Console.WriteLine("Иттерация {2}:\t текущий Х = {0}, \tследующий Х = {1}", x, nextX, ++Count);
            return Math.Abs(x - nextX) < Delta ? nextX : SecondAlgoritm(nextX);
        }

        static double GetInitial(double a, double b)
        {
            return OurFunc(a) * SecondDerivativeOurFunc(a) > 0 ? a : b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите погрешность:");
            Delta = double.Parse(Console.ReadLine().Replace(".", ","));
            Console.WriteLine("Введите начало интервала:");
            var a = double.Parse(Console.ReadLine().Replace(".", ","));
            Console.WriteLine("Введите конец интервала:");
            var b = double.Parse(Console.ReadLine().Replace(".", ","));
            var x = SecondAlgoritm(GetInitial(a, b));
            Console.WriteLine("Ответ {0}", Math.Round(x, Delta.ToString().Length - 2));
            Console.ReadKey();
        }
    }
}