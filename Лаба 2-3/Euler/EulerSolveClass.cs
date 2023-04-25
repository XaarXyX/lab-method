namespace Euler
{
    public static class EulerSolveClass
    {
        public static List<Point> EilerMethod(int xStart, int xEnd, double step, double yStart, double yDerivative)
        {
            List<Point> points = new List<Point>();
            double[] k1;
            double[] y = new double[2];
            y[0] = yStart;
            y[1] = yDerivative;

            for (double x = xStart; x < xEnd; x += step)
            {
                k1 = F(x, y);
                for (int i = 0; i < 2; i++)
                {
                    Point point = new Point();
                    y[i] = y[i] + k1[i] * step;
                    point.x = x;
                    point.y = y;
                    points.Add(point);
                }
            }

            return points;
        }

        public static List<Point> ModifyEilerMethod(int xStart, int xEnd, double step, double yStart, double yDerivative)
        {
            List<Point> points = new List<Point>();
            double[] k1;
            double[] y = new double[2];
            y[0] = yStart;
            y[1] = yDerivative;

            for (double x = xStart; x < xEnd; x += step)
            {
                k1 = F(x + step, y);
                for (int i = 0; i < 2; i++)
                {
                    Point point = new Point();
                    y[i] = y[i] + (k1[i] + k1[i]) * step / 2.0;
                    point.x = x;
                    point.y = y;
                    points.Add(point);
                }
            }

            return points;
        }

        private static double[] F(double x, double[] searchElem)
        {
            double y = 0.1;
            double z = 0.5;

            double[] dy = new double[searchElem.Length];
            dy[0] = Math.Cos(y + 2 * z) + 4;
            dy[1] = 2 / (x + 4 * y) + x + 1;

            return dy;
        }
    }
}