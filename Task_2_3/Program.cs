using System;

namespace Task_2_3
{
    class Program
    {

        static int Main(string[] args)
        {
            if (args.Length != 0)
            {
                try
                {
                    return (int)CommandMode(args);
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                DialogMode();
            }

            return 1;
        }
        private static void DialogMode()
        {
            Console.WriteLine("Array statistics");
            Console.WriteLine("Author: Ivan Halych");
            
            int length;
            while (true)
            {
                Console.WriteLine("Enter length array");
                if (int.TryParse(Console.ReadLine(),out length)) break;
            }
            int[] array = new int[length];
            for (int i = 0; i < array.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Enter {i + 1} element: ");
                    if(int.TryParse(Console.ReadLine(),out array[i])) break;
                }
            }
            Console.WriteLine(Statistic(array));
        }

        private static int CommandMode(string[] args)
        {
            int[] array = new int[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                array[i] = int.Parse(args[i]);
            }
            Console.WriteLine(Statistic(array));
            return 1;
        }

        static string Statistic(int[] array)
        {
            string result = "";
            array = Sort(array);
            result += $"Min: {array[0]}\n";
            result += $"Max: {array[array.Length-1]}\n";
            int sum = 0;
            foreach(int i in array)
            {
                sum += i;
            }
            result += $"Sum: {sum}\n";
            result += $"Arithmetic Mean: {ArithmeticMean(array)}\n";
            result += $"Standard Deviation: {StandardDeviation(array)}\n";
            result += Print(array);
            return result;
        }
        static string Print(int[] array)
        {
            string result = "";
            foreach (int i in array)
            {
                result += $" {i}";
            }
            return result;
        }
        static int[] Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int h = array[i];
                        array[i] = array[j];
                        array[j] = h;
                    }
                }
            }
            return array;
        }
        static int ArithmeticMean(int[] array)
        {
            int sum = 0;
            foreach (int i in array)
            {
                sum += i;
            }

           return sum / array.Length;
        }
        static int StandardDeviation(int[] array)
        {
            int arithmeticMean = ArithmeticMean(array);
            int standardDeviation = 0;
            foreach (int i in array)
            {
                int t = i - arithmeticMean;
                t = t * t;
                standardDeviation += t;
            }
            standardDeviation /= array.Length;
            standardDeviation = (int)Math.Sqrt(standardDeviation);
            return standardDeviation;
        }
    }
}
