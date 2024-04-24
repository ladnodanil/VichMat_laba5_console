using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VichMat_laba5_console
{
    public static class NumericalIntegration
    {
        private static double Function(double x)
        {
            if (x < 0)
                throw new Exception("sdad");
            return ((1 + Math.Sqrt(x)) / (1 + 4 * x + 3 * Math.Pow(x, 2)));
            
        }

        public static void LeftRectangleMethod(double a, double b, double epsilon)
        {
            double S(double min, double max, double step)
            {
                int n = (int)((max - min) / step);

                double result = 0;
                for (int i = 0; i < n; i++)
                {
                    result += Function(a + (i * step));
                }
                result *= step;
                return result;
            }

            // начальный шаг
            double h = (b - a);

            int r = 2;
            double Mh = 1;
            while (Math.Abs(Mh) > epsilon)
            {

                Mh = (S(a, b, h) - S(a, b, h / r)) / 1;
                h /= r;
            }
            Console.WriteLine($"Метод левых прямоугольников интеграл равен S = {S(a, b, h)} с шагом h = {h} и точностью {epsilon}");
        }


        public static void MiddleRectangleMethod(double a, double b, double epsilon)
        {
            double S(double min, double max, double step)
            {
                int n = (int)((max - min) / step);

                double result = 0;
                for (int i = 0; i < n; i++)
                {
                    result += Function(a + (i * step) + step / 2);
                    
                }
                result *= step;
                return result;
            }
            double h = (b - a);



            int r = 2;
            double Mh = 1;
            while (Math.Abs(Mh) > epsilon)
            {

                Mh = (S(a, b, h) - S(a, b, h / r)) / 1;
                h /= r;
            }
            Console.WriteLine($"Метод средних прямоугольников интеграл равен S = {S(a, b, h)} с шагом h = {h} и точностью {epsilon}");
            
        }

        public static void NewtonCotesMethod_5(double a, double b, double epsilon)
        {
            double c0 = 5d / 288;
            double[] wi = { 19, 75, 50, 50, 75, 19 };

            double h = (b - a) / 5; // начальный шаг


            double S(double min, double max, double step)
            {
                int n = (int)((max - min) / step);
                double result = 0;

                int i = 0, j = 0;

                double sum = 0;

                while(i <= n)
                {
                    double x = min + (i * step);

                    sum += wi[j] * Function(x);


                    if (j == 5 && i <= n)
                    {
                        result += c0 * step * sum;
                        j = 0;
                        sum = 0;
                    }
                    else
                    {
                        j++;
                        i++;
                    }

                }

                return result;
            }

            int r = 5;
            double Mh = 1;
            while (Math.Abs(Mh) > epsilon)
            {
                int n = (int)((b - a) / h);

                if (n % 5 == 0)
                {
                    Mh = (S(a, b, h) - S(a, b, h / r)) / (Math.Pow(r, 5) - 1);

                }
                h /= r;
            }
            Console.WriteLine($"Метод 5 порядка интеграл равен S = {S(a, b, h)} с шагом h = {h} и точностью {epsilon}");
        }

    }
}
