using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_1
{
    class RockPaperScissors
    {
        enum Game { Rock = 0, Paper = 1, Scissors = 2 };
        static int[,] ResultGame = { { 1, 0, 2 }, { 2, 1, 0 }, { 0, 2, 1 } };
        int countWin = 0;
        int countDraw = 0;
        int countLose = 0;
        public void Run()
        {
            Console.WriteLine("Game Stone-Scissors-Paper.");
            Console.WriteLine("Author: Ivan Halych");
            Console.WriteLine("Rules: The user enters one of the shape options (rock, scissors or paper),\n" +
                " and the computer offers his version at random. Depending on the choice of the user and the computer,\n" +
                " the result of the game is displayed: the victory of the user; loss of the user; draw.");
            Command();
            while (true)
            {
                Console.Write("You: ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "Rock":
                        RunGame(Game.Rock);
                        break;
                    case "Paper":
                        RunGame(Game.Paper);
                        break;
                    case "Scissors":
                        RunGame(Game.Scissors);
                        break;
                    case "Exit":
                        Statistic();
                        return;
                    default:
                        Console.WriteLine("Input error.");
                        Command();
                        break;
                }
            }
        }
        void RunGame(Game game)
        {
            Game enemy = (Game)(new Random().Next(0, 3));
            int result = ResultGame[(int)game, (int)enemy];
            Console.WriteLine($"Computer: {((Game)enemy).ToString()}");
            switch (result)
            {
                case 0:
                    countLose++;
                    Console.WriteLine("loss of the user");
                    break;
                case 1:
                    countDraw++;
                    Console.WriteLine("draw");
                    break;
                case 2:
                    countWin++;
                    Console.WriteLine("the victory of the user");
                    break;
            }
        }
        void Statistic()
        {
            Console.WriteLine($"Win: {countWin}");
            Console.WriteLine($"Draw: {countDraw}");
            Console.WriteLine($"Lose: {countLose}");
        }
        void Command()
        {
            Console.WriteLine("Command:\n" +
                "Rock\n" +
                "Paper\n" +
                "Scissors\n" +
                "Exit\n");
        }
        
    }
}
