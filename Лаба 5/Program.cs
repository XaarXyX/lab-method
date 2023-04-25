using System;

class Program
{
    static void Main(string[] args)
    {
        const double A = 0.2;
        const double B = 1.0;
        const double h = 0.1;
        int n = (int)((B - A) / h) + 1;

        double[] x = new double[n];
        double[] y = new double[n];
        double[] z = new double[n];

        // Задание начальных условий
        x[0] = A;
        y[0] = 0.9;
        z[0] = y[0] - 0.2;

        // Расчет сеточной функции
        for (int i = 1; i < n; i++)
        {
            x[i] = x[i - 1] + h;
            z[i] = z[i - 1] + h * (2 * x[i - 1] * z[i - 1] - y[i - 1] + 0.5);
            y[i] = y[i - 1] + h * z[i - 1];
        }

        // Задание краевых условий
        double k = (y[n - 1] - y[n - 2]) / h;
        y[n - 1] = y[n - 2] + h * 1;
        z[n - 1] = k + 1;

        // Вывод результатов
        Console.WriteLine(" x\t  y");
        Console.WriteLine("--------------");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{x[i]:F4}\t{y[i]:F4}");
        }
    }
}