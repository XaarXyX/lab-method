using System;

namespace Integral.Methods
{
    public static class Trapezoids
    {
        public static double Decision(double a, double b, double step, Program.FuncDelegate function)
        {
            double result = 0;

            for (var i = a; i < b; i += step)
            {
                double begin = function(i); // Начало трапеции
                double end = function(i + step); // Конец трапеции

                var stepResult = (begin + end) / 2 * step; // Площадь трапеции
                result += stepResult;
            }

            return Math.Round(result, 4);
        }
    }
}