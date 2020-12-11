using System;

namespace Task_1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeNumbers();
        }
        static void PrimeNumbers()
        {
            Console.WriteLine("Search for prime numbers.");
            Console.WriteLine("Author: Ivan Halych");
            Console.WriteLine("Enter the lower limit");
            int lower = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the upper limit");
            int upper = int.Parse(Console.ReadLine());
            Console.WriteLine("List of prime numbers");
            for (int i = lower; i <= upper; i++)
            {
                if (IsPrimeNumber(i))
                    Console.WriteLine(i);
            }
        }
        static bool IsPrimeNumber(int n)
        {
            bool result = true;
            if (n > 1)
            {
                for (var i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
