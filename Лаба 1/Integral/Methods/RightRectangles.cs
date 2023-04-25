using System;

namespace Integral.Methods
{

    public static class RightRectangles
    {
        public static double Decision(double a, double b, double step, Program.FuncDelegate function)
        {
            double result = 0;

            for (var i = a; i < b; i += step)
            {
                var stepResult = function((i + step) * step);  // Площадь прямоугольника
                result += stepResult;
            }

            return Math.Round(result, 4);
        }
    }
}