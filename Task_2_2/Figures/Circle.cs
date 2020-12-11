using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_2.Figures
{
    class Circle : Figure
    {
        private double r;
        public Circle(double r)
        {
            this.r = r;
        }
        public static Circle NewCircle()
        {
            double r;
            while (true)
            {
                Console.Write("Enter r: ");
                double x = Parameter();
                if (x == -2) return null;
                if (!(x == -1))
                {
                    r = x;
                    break;
                }
                
            }
            return new Circle(r);
        }
        public override double Area()
        {
            return Math.PI * r * r;
        }
    }
}
