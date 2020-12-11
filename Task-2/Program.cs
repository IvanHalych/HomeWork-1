using System;

namespace Task_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate();
        }
        static void Calculate()
        {
            Console.WriteLine("Calculation of the chances of different results and the bookmaker's margin.");
            Console.WriteLine("Author: Ivan Halych");
            Console.WriteLine("Please enter name player-1");
            String player1 = Console.ReadLine();
            Console.WriteLine("Please enter name player-2");
            String player2 = Console.ReadLine();
            Console.WriteLine("Please enter W1");
            double w1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter D");
            double d = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter W2");
            double w2 = double.Parse(Console.ReadLine());
            double margin = 100 - (100 / w1) - (100 / d) - (100 / w2);
            double W1 = (100 - margin) / w1;
            double D = (100 - margin) / d;
            double W2 = (100 - margin) / w2;
            Console.WriteLine($"Win {player1} = {W1}%");
            Console.WriteLine($"Draw = {D}%");
            Console.WriteLine($"Win {player2} = {W2}%");
            Console.WriteLine($"Margin = {margin}%");

        }
    }
}
