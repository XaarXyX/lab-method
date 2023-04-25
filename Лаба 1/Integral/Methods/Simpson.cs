using System;

namespace Integral.Methods
{
    public static class Simpson
    {
        public static double Decision(double a, double b, double step, Program.FuncDelegate function)
        {
            double result = 0;
            var middle = function((a + b) / 2);  // Середина фигуры

            for (var i = a; i < b; i += step)
            {
                var begin = function(i);  // Начало фигуры
                var end = function(i + step);  // Конец фигуры

                var stepResult = (begin + 4 * middle + end) / 6 * step;  // Площадь фигуры
                result += stepResult;
            }

            return Math.Round(result, 4);
        }
    }
}