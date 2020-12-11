using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_2.Figures
{
    abstract class Figure
    {
        public abstract double Area();

        public static double Parameter()
        {
            string number = Console.ReadLine();
            if (number == "Exit") return -2;
            double x;
            if (!double.TryParse(number, out x))
            {
                Console.WriteLine("Error input parameter");
                Rule();
                return -1;
            }
            else
            {
                if (x <= 0)
                {
                    Console.WriteLine("Error input parameter");
                    Rule();
                    return -1;
                }
                return x;
            }

        }
        public static void Rule()
        {
            Console.WriteLine("Rule:");
            Console.WriteLine("Parameter > 0.");
            Console.WriteLine($"Parameter <= {double.MaxValue}");
            Console.WriteLine("Parameter type is double.");

        }
    }
}
