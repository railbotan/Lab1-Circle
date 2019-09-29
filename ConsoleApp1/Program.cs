using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int Count;

        static double Delta;

        static double Func(double x)
        {
            return x * x * x + 4 * x - 4;
        }

        static double FirstAlgoritm(double a, double b)
        {
            var x = (a + b) / 2;
            Console.WriteLine("Иттерация {2}:\tтекущий интервал [ {0} ; {1} ],\tсередина интервала {3}", a, b, ++Count, x);
            if (CheckFinish(a, b))
            {
                return GenerateAnswer(a, x, b);
            }
            if (CheckInterval(a, x))
            {
                return FirstAlgoritm(a, x);
            }
            else
            {
                return FirstAlgoritm(x, b);
            }
        }

        public static bool CheckInterval(double a, double b)
        {
            return Func(a) * Func(b) < 0;
        }

        public static bool CheckFinish(double a, double b)
        {
            return Math.Abs(Func(a) - Func(b)) < Delta || Math.Abs(a - b) < Delta;
        }

        public static double GenerateAnswer(params double[] args)
        {
            return args.Select(x => (Value: x, FuncResult: Math.Abs(Func(x))))
            .OrderBy(x => x.FuncResult)
            .First().Value;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Метод деления отрезка пополам.");
            Console.WriteLine("Введите погрешность:");
            Delta = double.Parse(Console.ReadLine().Replace(".", ","));
            Console.WriteLine("Введите начало интервала:");
            var a = double.Parse(Console.ReadLine().Replace(".", ","));
            Console.WriteLine("Введите конец интервала:");
            var b = double.Parse(Console.ReadLine().Replace(".", ","));
            if (!CheckInterval(a, b))
            {
                Console.WriteLine("Введен неверный интервал!");
                Console.ReadKey();
                return;
            }
            var x = FirstAlgoritm(a, b);
            Console.WriteLine("Ответ {0}", Math.Round(x / Delta) * Delta);
            Console.ReadKey();
        }
    }
}