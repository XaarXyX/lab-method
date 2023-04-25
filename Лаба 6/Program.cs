
using System;

class Program
{
    static double TargetFunction(double x1, double x2)
    {
        return Math.Pow(1 - x1, 2) + 5 * Math.Pow(x2 - x1 * x1, 2);
    }

    static double GradientX1(double x1, double x2)
    {
        return 2 * (2 * x1 * x1 * x1 - 2 * x1 * x2 - x1 + 1);
    }

    static double GradientX2(double x1, double x2)
    {
        return 10 * (x2 - x1 * x1);
    }

    static double Norm(double x1, double x2)
    {
        return Math.Sqrt(Math.Pow(GradientX1(x1, x2), 2) + Math.Pow(GradientX2(x1, x2), 2));
    }

    static double Minimize(Func<double, double, double> func, Func<double, double, double> gradX1, Func<double, double, double> gradX2, Func<double, double, double> lambdaFunc, double epsilon, double startX1, double startX2)
    {
        double x1 = startX1;
        double x2 = startX2;
        double gradientX1 = gradX1(x1, x2);
        double gradientX2 = gradX2(x1, x2);

        while (Norm(x1, x2) > epsilon)
        {
            double lambda = lambdaFunc(x1, x2);
            x1 -= lambda * gradientX1;
            x2 -= lambda * gradientX2;
            gradientX1 = gradX1(x1, x2);
            gradientX2 = gradX2(x1, x2);
        }

        return func(x1, x2);
    }

    static double FindLambda(double x1, double x2)
    {
        double lambda = 0.01;
        double alpha = 0.3;
        double beta = 0.5;

        while (Norm(x1 - lambda * GradientX1(x1, x2), x2 - lambda * GradientX2(x1, x2)) >= (1 - alpha * lambda) * Norm(x1, x2))
        {
            lambda *= beta;
        }

        return lambda;
    }

    static void Main(string[] args)
    {
        double epsilon = 0.01;
        double startX1 = 1;
        double startX2 = 0;

        Func<double, double, double> func = (x1, x2) => TargetFunction(x1, x2);
        Func<double, double, double> gradX1 = (x1, x2) => GradientX1(x1, x2);
        Func<double, double, double> gradX2 = (x1, x2) => GradientX2(x1, x2);
        Func<double, double, double> lambdaFunc = (x1, x2) => FindLambda(x1, x2);

        double minimum = Minimize(func, gradX1, gradX2, lambdaFunc, epsilon, startX1, startX2);

        Console.WriteLine("Минимальное значение функции: " + minimum);
    }
}