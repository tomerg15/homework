using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp89
{
    class Game
    {
        private int? Points;
        private GameStatus _gamestatus = GameStatus.Idle;
        private int?[,] Data;
        private Board DataBoard = new Board(new int?[4, 4]);
        public Game(int?[,] Data)
        {
            this.Data = Data;
            DataBoard = new Board(Data);
            for (int i = 0; i < DataBoard.GetData().GetLength(0); i++)
            {
                for (int j = 0; j < DataBoard.GetData().GetLength(1); j++)
                {
                    if (DataBoard.GetData()[i, j] == null)
                    {
                        Console.Write("[ ]");
                    }
                    else
                    {
                        Console.Write("[" + DataBoard.GetData()[i, j] + "]");
                    }
                }
                Console.WriteLine();
            }
        }
        public int? GetPoints()
        {
            return Points;
        }
        protected void SetPoints(int? Points)
        {
            this.Points = Points;
            Console.WriteLine("Points: " + Points);
        }

        public void Move(Direction _direction)
        {
            if(_gamestatus.ToString() == GameStatus.Idle.ToString())
            {
                int? temp_points = DataBoard.Move(_direction);
                SetPoints(temp_points);
                for (int i = 0; i < DataBoard.GetData().GetLength(0); i++)
                {
                    for (int j = 0; j < DataBoard.GetData().GetLength(1); j++)
                    {
                        if (DataBoard.GetData()[i, j] == null)
                        {
                            Console.Write("[ ]");
                        }
                        else
                        {
                            Console.Write("[" + DataBoard.GetData()[i, j] + "]");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
