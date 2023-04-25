using System;

class Program
{
    static void Main(string[] args)
    {
       

        double x = 0;
        double y = C;
        double z1 = D;
        double z2 = D + h;

        // используем метод итераций для нахождения z на правой границе,
        // удовлетворяющего граничному условию y(B) = E
        double z;
        do
        {
            z = z2 - (z2 - z1) * (y - E) / (Gety(x, z2) - E);
            z1 = z2;
            z2 = z;
        } while (Math.Abs(y - E) > eps);

        Console.WriteLine($"y({B}) = {y:F4}");
        Console.WriteLine($"z({B}) = {z:F4}");
    }

    // функция для вычисления значения y(x) по заданным значениям x и z
    static double Gety(double x, double z)
    {
        const double p = 1;
        const double q = 1;
        const double f = 1;

        // используем метод Эйлера для решения дифференциального уравнения
        double y = C;
        double dy = z;

        for (double i = x; i < B; i += h)
        {
            double ddy = f - p * Math.Sinh(i) * dy - q * i * y;
            dy += ddy * h;
            y += dy * h;
        }

        return y;
    }

    // константы из условия задачи
    const double A = 0;
    const double B = 1;
    const double C = 2;
    const double D = 0;
    const double E = 1;
    const double F = 2;
    const double eps = 1e-6; // точность
    const double h = 0.01; // шаг
}