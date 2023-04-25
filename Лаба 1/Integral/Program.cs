using System;
using Integral.Methods;

namespace Integral
{
    public class Program
    {
        public delegate double FuncDelegate(double number);
        static void Main(string[] args)
        {
            double Function(double number) => Math.Pow(number, 2);
            FuncDelegate funcDelegate = Function;

            Console.Write("Начало отрезка (a): ");
            var a = int.Parse(Console.ReadLine());

            Console.Write("Конец отрезка (b): ");
            var b = int.Parse(Console.ReadLine());

            Console.Write("Длина шага (h): ");
            var step = double.Parse(Console.ReadLine());

            double q = 2;

            // Будем использовать метод средних прямоугольников
            double F1 = MiddleRectangles.Decision(a, b, step, funcDelegate);
            double F2 = MiddleRectangles.Decision(a, b, step * q, funcDelegate);
            double F3 = MiddleRectangles.Decision(a, b, step * Math.Pow(q, 2), funcDelegate);

            Console.WriteLine(F1);

            double result = Math.Pow(Math.Log(q, Math.E), -1) * Math.Log((F3 - F2) / (F2 - F1), Math.E);
            Console.WriteLine($"Результат процесса Эйткена: {result}");
        }
    }
}
