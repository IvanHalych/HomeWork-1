using System;

namespace Task_1_1
{
    class Program
    {
        const short b = 1999;   //BirthYear
        const byte c = 7;      //BirthMonth
        const byte d = 7;        //BirthDay
        static void Main(string[] args)
        {
            MathFunction();
        }
        static void MathFunction()
        {
            Console.WriteLine("The value of functions with the set parameter is calculated.");
            Console.WriteLine("Author: Ivan Halych");
            Console.WriteLine("y = ((e^a) +4* lg c) / sqrt(b) * abs(arctg(d)) +(5/(sin a))");
            Console.WriteLine($"b = {b}\n" +
                $"c = {c}\n" +
                $"d = {d}");
            Console.WriteLine("Please enter a parameter");
            double a = double.Parse(Console.ReadLine());
            double y = Math.Pow(Math.E, a);
            y += 4 * Math.Log10(c);
            y /= Math.Sqrt(b);
            y *= Math.Abs(Math.Atan(d));
            y += 5 / Math.Sin(a);
            Console.WriteLine($"y = {y}");
        }
    }
}
