using Euler;

double y = 0.1;
double z = 1;
int xStart = 0;
int xEnd = 1;
double step = 0.01;

List<Point> points = new List<Point>();

points = EulerSolveClass.ModifyEilerMethod(xStart, xEnd, step, y, z);

foreach (var point in points)
{
    Console.WriteLine("------------------------------------");
	for (int i = 0; i < point.y.Length; i++)
	{
        Console.Write(i + 1 + ":");
        Console.WriteLine($"|{point.x}\t | {point.y[i]}|");

    }
}