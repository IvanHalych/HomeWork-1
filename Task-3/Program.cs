using System;

namespace Task_1_3
{
    class Program
    {
        const double epsilon = 1d / 1999d;
        static void Main(string[] args)
        {
            SumNumber();
        }
        static void SumNumber()
        {
            Console.WriteLine("Calculate the sum of the series.");
            Console.WriteLine("Author: Ivan Halych");
            double sum = 0;
            double number = 0;
            double i = 1;
            do
            {
                number = 1 / (i * (i + 1));
                sum += number;
                i++;
            }
            while (number >= epsilon);
            Console.WriteLine($"Sum = {sum}");
        }
    }
}
