using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace PDE_Solver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задаем начальные условия
            double L = 0.6; // Длина стержня
            int N = 20; // Количество точек равномерной сетки по x
            double h = L / (N - 1);
            double dt = 0.001; // Шаг по времени
            int M = 10000; // Количество шагов по времени
            double[,] U = new double[N, M]; // Массив значений функции U в узлах сетки

            // Инициализируем начальное состояние
            for (int i = 0; i < N; i++)
            {
                U[i, 0] = Math.Sin(i * h) + 0.08; // f(x)
            }

            // Задаем граничные условия
            for (int j = 0; j < M; j++)
            {
                U[0, j] = 0.08 + 2 * j * dt; // F(t)
                U[N - 1, j] = 0.644 * j * dt; // Y(t)
            }

            // Решаем уравнение методом конечных разностей
            double alpha = dt / (h * h);
            for (int j = 0; j < M - 1; j++)
            {
                for (int i = 1; i < N - 1; i++)
                {
                    U[i, j + 1] = alpha * (U[i + 1, j] - 2 * U[i, j] + U[i - 1, j]) + U[i, j];
                }
            }

            // Строим график
            PlotGraph(U, h, dt);
        }

        static void PlotGraph(double[,] U, double h, double dt)
        {
            int N = U.GetLength(0);
            int M = U.GetLength(1);

            // Создаем массивы для координат точек графика
            double[] x = new double[N];
            for (int i = 0; i < N; i++)
            {
                x[i] = i * h;
            }

            double[] t = new double[M];
            for (int j = 0; j < M; j++)
            {
                t[j] = j * dt;
            }

            // Создаем массив для значений функции на графике
            double[] u = new double[N * M];
            int k = 0;
            for (int j = 0; j < M; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    u[k] = U[i, j];
                    k++;
                }
            }

            // Строим график с помощью библиотеки OxyPlot
            var plotModel = new OxyPlot.PlotModel();
            var heatMapSeries = new OxyPlot.Series.HeatMapSeries
            {
                X0 = 0,
                X1 = N - 1,
                Y0 = 0,
                Y1 = M - 1,
                Interpolate = false,
                Data = u,
                RenderMethod = OxyPlot.Series.HeatMapRenderMethod.Bitmap
            };
            plotModel.Series.Add(heatMapSeries);
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom, Title = "x" });
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Left, Title = "t" });
            var plotView = new OxyPlot.WindowsForms.PlotView();
            plotView.Model = plotModel;
            plotView.Dock = System.Windows.Forms.DockStyle.Fill;
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            form.Controls.Add(plotView);
            form.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            form.ShowDialog();
        }
    }
}