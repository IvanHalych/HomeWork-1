using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_2.Figures
{
    class Triangle :Figure
    {
        private double a;
        private double b;
        private double c;
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public static Triangle NewTriangle()
        {
            double a;
            double b;
            double c;
            while (true)
            {
                Console.Write("Enter a: ");
                double x = Parameter();
                if (x == -2) return null;
                if (!(x == -1))
                {
                    a = x;
                    break;
                }

            }
            while (true)
            {
                Console.Write("Enter b: ");
                double x = Parameter();
                if (x == -2) return null;
                if (!(x == -1))
                {
                    b = x;
                    break;
                }

            }
            while (true)
            {
                Console.Write("Enter c: ");
                double x = Parameter();
                if (x == -2) return null;
                if (!(x == -1))
                {
                    c = x;
                    break;
                }

            }
            return new Triangle(a, b, c);
        }
    
        public override double Area()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p*(p-a)*(p-b)*(p-c));
        }
    }
}
