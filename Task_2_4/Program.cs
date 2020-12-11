using System;
using System.Diagnostics;

namespace Task_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Game(); 
        }
        static void Game()
        {
            Console.WriteLine("The game is more less");
            Console.WriteLine("Author: Ivan Halych");
            Console.WriteLine("Rule: The user wants to guess the number that the computer guessed in a given range.\n" +
                " The user wants to receive hints “more” and “less” if the number was not guessed.\n" +
                " The user wants to get points for the minimum number of used attempts to guess the number.");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int attempt = 1;
            int score = 0;
            int lower;
            int higher;
            while (true)
            {
                Console.WriteLine("Enter range from 0 to 1.000.000");
                string[] array = Console.ReadLine().Split("-");
                if (array.Length==2)
                    if (array[0] != null && array[1] != null)
                        if (int.TryParse(array[0], out lower) && (int.TryParse(array[1], out higher)))
                        {
                            if ((lower >= 0) && (lower <= 1000000) && (higher >= 0) && (higher <= 1000000))
                                break;
                        }
            }
            int findNumber = new Random().Next(lower,higher);
            while (true)
            {
                Console.Write($"Attempt {attempt} \nEnter number:");
                string command = Console.ReadLine();
                if (command == "Exit")
                {    
                    stopWatch.Stop();
                    Statistic(score, attempt, stopWatch);
                    return;
                }
                int number;
                if (int.TryParse(command, out number))
                {
                    if (findNumber == number)
                    {
                        stopWatch.Stop();
                        Console.WriteLine("\nYou win");
                        break;
                    }
                    else
                    {
                        if (findNumber > number)
                        {
                            Console.WriteLine("More\n");
                        }
                        else
                        {
                            Console.WriteLine("Less\n");
                        }
                        attempt++;
                    }
                }
                else
                {
                    Console.WriteLine("Error input");
                }
            }
            score = Score(higher, lower, attempt);
            Statistic(score, attempt, stopWatch);
            
        }
        static void Statistic(int score,int attempt, Stopwatch stopWatch)
        {
            if (score <= 0) score = 1;
            Console.WriteLine($"Score: {score}");
            Console.WriteLine($"Attempt: {attempt}");
            Console.WriteLine("Time : {0:hh\\:mm\\:ss\\.fffffff}", stopWatch.Elapsed);
        }
        static int Score( int higher,int lower, int attempt)
        {
            int variants = higher - lower + 1;
            int n = 0;
            int pow2N = (int)Math.Pow(2, n);
            while (true)
            {
                if (Math.Abs(variants - pow2N) < (Math.Abs(Math.Pow(2, n + 1))))
                {
                    break;
                }
                n++;
                pow2N = (int)Math.Pow(2, n);
            }
            int score = 100 * (n - attempt + 1) / n;
            score = (int)Math.Ceiling((double)score);
            return score;
        }
    }
}
