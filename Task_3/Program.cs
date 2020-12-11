using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task_3
{
    class Program
    {
        delegate double BinaryOperation(double a, double b);
        delegate int BitOperation(int a, int b);
        static void Main(string[] args)
        {
            Calculation();
        }
        static void Calculation()
        {
            Console.WriteLine("Сalculator");
            Console.WriteLine("Author: Ivan Halych");
            Console.WriteLine("The user can enter expressions in one line (for example “5 + 3”) and get the result.");
            Console.WriteLine("Command:\n" +
                "Help\n" +
                "Exit");
            while (true)
            {
                Console.WriteLine("Enter an expression or command");
                string expresion = Console.ReadLine();
                if (expresion == "Exit")
                {
                    break;
                }
                if (expresion == "Help")
                {
                    Expresions();
                    continue;
                }
                try
                {
                    OnePass(expresion);
                }
                catch (System.OverflowException e)
                {
                    Console.WriteLine("UNCHECKED and CAUGHT:  " + e.ToString());
                    continue;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }
            }
        }
        static void OnePass(string expresion)
        {
            string[] array= expresion.Split(" ");
            expresion = "";
            foreach(string i in array)
            {
                expresion += i;
            }
            Regex regex;
            foreach (KeyValuePair<string, BinaryOperation> keyValue in GetBinaryOperation())
            {
                regex = new Regex(@$"^-?\d+([\,]\d+)?[{keyValue.Key}]-?\d+([\,]\d+)?$");
                if (regex.IsMatch(expresion))
                {
                    string[] numbers = expresion.Split(keyValue.Key);
                    double number1;
                    double number2;
                    if (double.TryParse(numbers[0], out number1) && (double.TryParse(numbers[1], out number2)))
                    {
                        Console.WriteLine(keyValue.Value.Invoke(number1, number2));
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Error input.Please use Help.");
                        return;
                    }
                }
            }
            regex = new Regex(@$"^-?\d+([\,]\d+)?[\\]-?\d+([\,]\d+)?$");
            if (regex.IsMatch(expresion))
            {
                string[] numbers = expresion.Split("\\");
                double number1;
                double number2;
                if (double.TryParse(numbers[0], out number1) && (double.TryParse(numbers[1], out number2)))
                {
                    Console.WriteLine(Division(number1, number2));
                    return;
                }
                else
                {
                    Console.WriteLine("Error input.Please use Help.");
                    return;
                }
            }
            regex = new Regex(@$"^-\d+([\,]\d+)?[-]-\d+([\,]\d+)?$");
            if (regex.IsMatch(expresion))
            {
                string[] numbers = expresion.Split("-");
                double number1;
                double number2;
                if (double.TryParse(numbers[1], out number1) && (double.TryParse(numbers[3], out number2)))
                {
                    Console.WriteLine(Subtraction(-number1, -number2));
                    return;
                }
                else
                {
                    Console.WriteLine("Error input.Please use Help.");
                    return;
                }
            }
            regex = new Regex(@$"^\d+([\,]\d+)?[-]-\d+([\,]\d+)?$");
            if (regex.IsMatch(expresion))
            {
                string[] numbers = expresion.Split("-");
                double number1;
                double number2;
                if (double.TryParse(numbers[0], out number1) && (double.TryParse(numbers[2], out number2)))
                {
                    Console.WriteLine(Subtraction(number1, -number2));
                    return;
                }
                else
                {
                    Console.WriteLine("Error input.Please use Help.");
                    return;
                }
            }
            regex = new Regex(@$"^\d+([\,]\d+)?[-]\d+([\,]\d+)?$");
            if (regex.IsMatch(expresion))
            {
                string[] numbers = expresion.Split("-");
                double number1;
                double number2;
                if (double.TryParse(numbers[0], out number1) && (double.TryParse(numbers[1], out number2)))
                {
                    Console.WriteLine(Subtraction(number1, number2));
                    return;
                }
                else
                {
                    Console.WriteLine("Error input.Please use Help.");
                    return;
                }
            }
            foreach (KeyValuePair<string, BitOperation> keyValue in GetBitOperation())
            {
                regex = new Regex(@$"^-?\d+[\{keyValue.Key}]-?\d+$");
                if (regex.IsMatch(expresion))
                {
                    string[] numbers = expresion.Split(keyValue.Key);
                    int number1;
                    int number2;
                    if (int.TryParse(numbers[0], out number1) && (int.TryParse(numbers[1], out number2)))
                    {
                        if (number1 <= 0 || number2 <= 0)
                        {
                            Console.WriteLine("Error input, number <= 0 .Please use Help.");
                            return;
                        }
                        Console.WriteLine(keyValue.Value.Invoke(number1, number2));
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            regex = new Regex(@$"^[\!]-?\d+$");
            if (regex.IsMatch(expresion))
            {
                string[] numbers = expresion.Split("!");
                int number1;
                if (int.TryParse(numbers[1], out number1))
                {
                    if (number1 <= 0)
                    {
                        Console.WriteLine("Error input, number <= 0 .Please use Help.");
                        return;
                    }
                    Console.WriteLine(NOT(number1));
                    return;
                }
                else
                {
                    return;
                }
            }
            regex = new Regex(@$"^-?\d+[\!]$");
            if (regex.IsMatch(expresion))
            {
                string[] numbers = expresion.Split("!");
                int number1;
                if (int.TryParse(numbers[0], out number1))
                {
                    if (number1 <= 0)
                    {
                        Console.WriteLine("Error input, number <= 0 .Please use Help.");
                        return;
                    }
                    Console.WriteLine(Factorial(number1));
                    return;
                }
                else
                {
                    return;
                }
            }
            regex = new Regex(@$"^-?\d+([\,]\d+)?$");
            if (regex.IsMatch(expresion))
            {
                double number;
                if (double.TryParse(expresion, out number)) ;
                Console.WriteLine(number);
                return;
            }
            Console.WriteLine("Error input.Please use Help.");
        }
        static Dictionary<string, BinaryOperation> GetBinaryOperation()
        {
            Dictionary<string, BinaryOperation> binaryOperations = new Dictionary<string, BinaryOperation>(7);
            binaryOperations.Add("+", Addition);
            binaryOperations.Add("*", Multiplication);
            binaryOperations.Add("x", Multiplication);
            binaryOperations.Add("/", Division);
            binaryOperations.Add("%", Remainder);
            binaryOperations.Add("pow", Addition);
            return binaryOperations;
        }
        static Dictionary<string, BitOperation> GetBitOperation()
        {
            Dictionary<string, BitOperation> bitOpeations = new Dictionary<string, BitOperation>(3);
            bitOpeations.Add("&", AND);
            bitOpeations.Add("|", OR);
            bitOpeations.Add("^", XOR);
            return bitOpeations;
        }

    static double Addition(double a,double b)
        {
            return checked( a + b);
        }
        static double Subtraction(double a, double b)
        {
            return checked(a - b);
        }
        static double Division(double a, double b)
        {
            return checked(a / b);
        }
        static double Multiplication(double a, double b)
        {
            return checked(a * b);
        }
        static double Power(double a, double b)
        {
            return checked(Math.Pow(a, b));
        }
        static double Remainder(double a, double b)
        {
            return checked(a % b);
        }
        static int AND(int a,int b)
        {
            return checked(a & b);
        }
        static int OR(int a, int b)
        {
            return checked(a | b);
        }
        
        static int XOR(int a, int b)
        {
            return checked(a ^ b);
        }
        static int NOT(int a)
        {
            return checked(~a);
        }
        static int Factorial(int a)
        {
            int factorial = 1; 
            for(int i = a; i > 0; i--)
            {
               factorial= checked(factorial * i);
            }
            return factorial;
        }
        static void Expresions()
        {
            Console.WriteLine("Binary: a + b, a-b, a * b, a x b, a / b, a \\ b, a% b, a pow b (exponentiation)\n" +
                "Binary bit: a & b, a | b, a ^ b. Only positive operands.\n" +
                "Unary bitwise! A. Only positive operands. \n" +
                "Unary: a! (factorial), a (echo mode), -a (echo mode). \n");
        }
                
    }
}
