using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichMat_laba5_console
{
    public class Program
    {
        static void Menu()
        {

            Console.WriteLine("Введите границы");
            Console.Write("a = ");
            double a;
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out a))
            {
                Console.WriteLine("Ошибка ввода. Пожалуйста, введите допустимое числовое значение для a:");
            }

            Console.Write("b = ");
            double b;
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out b))
            {
                Console.WriteLine("Ошибка ввода. Пожалуйста, введите допустимое числовое значение для b:");
            }

            if (a >= b)
            {
                Console.WriteLine("Неверные границы, повторите ввод");
            }
            Console.Write("Введите точность: 10^");
            double epsilon = Math.Pow(10, Convert.ToDouble(Console.ReadLine()));
            NumericalIntegration.LeftRectangleMethod(a, b, epsilon);
            NumericalIntegration.MiddleRectangleMethod(a, b, epsilon);
            NumericalIntegration.NewtonCotesMethod_5(a, b, epsilon);

        }
        static void Main(string[] args)
        {
            Menu();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("0,5021893840266662");
            Console.ReadLine();
        }
    }
}
