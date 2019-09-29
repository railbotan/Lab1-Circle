using System;
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

        static double Func(double x)
        {
            return x * x * x + 4 * x - 4;
        }

        static double FirstDerivativeFunc(double x)
        {
            return 3 * x * x + 4; 
        }

        static double SecondDerivativeFunc(double x)
        {
            return 6 * x;
        }

        static double SecondAlgoritm(double x)
        {
            var nextX = x - Func(x) / FirstDerivativeFunc(x);
            Console.WriteLine("Иттерация {2}:\t текущий Х = {0}, \tследующий Х = {1}", x, nextX, ++Count);
            return Math.Abs(x - nextX) < Delta ? nextX : SecondAlgoritm(nextX);
        }

        static double GetInitial(double a, double b)
        {
            return Func(a) * SecondDerivativeFunc(a) > 0 ? a : b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите погрешность:");
            Delta = double.Parse(Console.ReadLine().Replace(".", ","));
            Console.WriteLine("Введите начало интервала:");
            var a = double.Parse(Console.ReadLine().Replace(".", ","));
            Console.WriteLine("Введите конец интервала:");
            var b = double.Parse(Console.ReadLine().Replace(".", ","));
            if (Func(a) * Func(b) >= 0)
            {
                Console.WriteLine("Введен неверный интервал!");
                Console.ReadKey();
                return;
            }
            var x = SecondAlgoritm(GetInitial(a, b));
            Console.WriteLine("Ответ {0}", Math.Round(x / Delta) * Delta);
            Console.ReadKey();
        }
    }
}