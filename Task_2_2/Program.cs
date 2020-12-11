using System;
using System.Reflection;
using Task_2_2.Figures;

namespace Task_2_2
{
    static class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 0)
            {
                try
                {
                    return (int)CommandMode(args);
                }
                catch (Exception )
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
        static double CommandMode(string[] args)
        {
            switch (args[0])
            {
                case "Circle":
                    return new Circle(double.Parse(args[1])).Area();
                case "Square":
                    return new Square(double.Parse(args[1])).Area();
                case "Rectangle":
                    return new Rectangle(double.Parse(args[1]), double.Parse(args[2])).Area();
                case "Triangle":
                    return new Triangle(double.Parse(args[1]), double.Parse(args[2]), double.Parse(args[3])).Area();
                default:
                    return -1;
            }
        }
        static void DialogMode()
        {
            Console.WriteLine("Calculation of the area of the figure");
            Console.WriteLine("Author: Ivan Halych");
            Figure.Rule();
            Command();
            while (true)
            {
                Console.WriteLine("Enter command");
                string figure = Console.ReadLine();
                Figure shape;
                switch (figure)
                {
                    case "Circle":
                        shape = Circle.NewCircle();
                        if (!(shape == null))
                            Console.WriteLine(shape.Area());
                        break;
                    case "Square":
                        shape = Square.NewSquare();
                        if (!(shape == null))
                            Console.WriteLine(shape.Area());
                        break;
                    case "Rectangle":
                        shape = Rectangle.NewRectangle();
                        if (!(shape == null))
                            Console.WriteLine(shape.Area());
                        break;
                    case "Triangle":
                        shape = Triangle.NewTriangle();
                        if (!(shape == null))
                            Console.WriteLine(shape.Area());
                        break;
                    case "Exit":
                        return;
                    default:
                        Console.WriteLine("Error input figure");
                        Command();
                        break;
                }
            }

        }
        static void Command()
        {
            Console.WriteLine("Command:\n" +
                "Circle\n" +
                "Square\n" +
                "Rectangle\n" +
                "Triangle\n" +
                "Exit\n");
        }

    }
}
