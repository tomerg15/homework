using System;

namespace ConsoleApp89
{
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }
    public enum GameStatus
    {
        Win,
        Lose,
        Idle
    }
    class ConsoleGame
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(38, 8);
            Console.WriteLine("Welcome to the C# version of 2048!");
            Console.WriteLine("Press one of the arrow keys to start!");
            Game game = new Game(new int?[4,4]);
            Direction direction = Direction.Up;
            GameStatus _gamestatus = GameStatus.Idle;
            while (_gamestatus.ToString() != "Lose" || _gamestatus.ToString() != "Win")
            {
                ConsoleKey direction_input = Console.ReadKey(false).Key;
                if (direction_input == ConsoleKey.UpArrow)
                {
                    direction = Direction.Up;
                }
                else if (direction_input == ConsoleKey.DownArrow)
                {
                    direction = Direction.Down;
                }
                else if (direction_input == ConsoleKey.RightArrow)
                {
                    direction = Direction.Right;
                }
                else if (direction_input == ConsoleKey.LeftArrow)
                {
                    direction = Direction.Left;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Key Pressed. Try Again.");
                    continue;
                }
                Console.Clear();
                game.Move(direction);
                int? points = game.GetPoints();
                if (points == -1)
                {
                    Console.Clear();
                    Console.WriteLine("Game Lost! Press anything to exit");
                    Console.ReadKey();
                    break;
                }
                if (points == -2)
                {
                    Console.Clear();
                    Console.WriteLine("Game Won! Press anything to exit");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
