using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_2.Figures
{
    class Square : Figure
    {
        private double a;
        public Square(double a)
        {
            this.a = a;
        }
        public static Square NewSquare()
        {
            double a;
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
            return new Square(a);
        }
        public override double Area()
        {
            return a*a;
        }
    }
}
