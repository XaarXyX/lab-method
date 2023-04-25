using System;

namespace Integral.Methods
{

    public static class MiddleRectangles
    {
        public static double Decision(double a, double b, double step, Program.FuncDelegate function)
        {
            double result = 0;

            for (var i = a; i < b; i += step)
            {
                var stepResult = function(i + step / 2.0) * step;  // Площадь прямоугольника
                result += stepResult;
            }

            return Math.Round(result, 4);
        }
    }
}