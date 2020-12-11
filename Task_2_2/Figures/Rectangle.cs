using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_2.Figures
{
    class Rectangle : Figure
    {
        private double a;
        private double b;
        public Rectangle(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public static Rectangle NewRectangle ()
        {
            double a;
            double b;
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
            return new Rectangle(a, b);
        }
        public override double Area()
        {
            return a * b;
        }
    }
}
