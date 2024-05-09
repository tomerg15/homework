using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp89
{
    class Board
    {
        private int?[,] Data;
        int? Points = 0;
        public Board(int?[,] data)
        {
            this.Data = data;
            FillTwoSpots();
        }
        public int?[,] GetData()
        {
            return this.Data;
        }
        protected void SetData(int?[,] data)
        {
            this.Data = data;
        }
        private void FillTwoSpots()
        {
            Random rnd = new Random();
            int count_spots_filled = 0;
            while (count_spots_filled < 2)
            {
                int i = rnd.Next(0, 4);
                int j = rnd.Next(0, 4);
                if (Data[i, j].HasValue == false)
                {
                    int temp = rnd.Next(0, 100);
                    if (temp % 2 == 0)
                    {
                        Data[i, j] = 2;
                    }
                    else
                    {
                        Data[i, j] = 4;
                    }
                    count_spots_filled += 1;
                }
            }
        }
        public void FillAfterMoving()
        {
            Random rnd = new Random();
            bool flag_filled_spot = false;
            bool completely_full = true;
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    if (Data[i, j].HasValue == false)
                    {
                        completely_full = false;
                    }
                }
            }
            if (completely_full == true)
            {
                Points = -1;
            }
            else
            {
                while (flag_filled_spot == false && completely_full == false)
                {
                    int i = rnd.Next(0, 4);
                    int j = rnd.Next(0, 4);
                    if (Data[i, j].HasValue == false)
                    {
                        int temp = rnd.Next(0, 100);
                        if (temp % 2 == 0)
                        {
                            Data[i, j] = 2;
                        }
                        else
                        {
                            Data[i, j] = 4;
                        }
                        flag_filled_spot = true;
                    }
                }
            }
        }

        public int? Move(Direction direction)
        {
            int?[,] old = (int?[,])Data.Clone();
            if (direction.ToString() == "Down")
            {
                int count = 0;
                while (count < 4)
                {
                    for (int i = 0; i < Data.GetLength(0) - 1; i++)
                    {
                        for (int j = 0; j < Data.GetLength(1); j++)
                        {
                            if (Data[i, j].HasValue == true)
                            {
                                if (Data[i + 1, j].HasValue == false)
                                {
                                    Data[i + 1, j] = Data[i, j];
                                    Data[i, j] = null;
                                }
                                else if (Data[i + 1, j] == Data[i, j])
                                {
                                    Data[i + 1, j] = Data[i, j] * 2;
                                    Points += Data[i, j] * 2;
                                    if (Data[i, j] * 2 == 2048)
                                    {
                                        GameStatus _gamestatus = GameStatus.Win;
                                        Points = -2;
                                    }
                                    Data[i, j] = null;
                                }
                            }
                        }
                    }
                    count += 1;
                }
            }
            if (direction.ToString() == "Up")
            {
                int count = 0;
                while (count < 4)
                {
                    for (int i = 1; i < Data.GetLength(0); i++)
                    {
                        for (int j = 0; j < Data.GetLength(1); j++)
                        {
                            if (Data[i, j].HasValue == true)
                            {
                                if (Data[i - 1, j].HasValue == false)
                                {
                                    Data[i - 1, j] = Data[i, j];
                                    Data[i, j] = null;
                                }
                                else if (Data[i - 1, j] == Data[i, j])
                                {
                                    Data[i - 1, j] = Data[i, j] * 2;
                                    Points += Data[i, j] * 2;
                                    if (Data[i, j] * 2 == 2048)
                                    {
                                        GameStatus _gamestatus = GameStatus.Win;
                                        Points = -2;
                                    }
                                    Data[i, j] = null;
                                }
                            }
                        }
                    }
                    count += 1;
                }
            }
            if (direction.ToString() == "Right")
            {
                int count = 0;
                while (count < 4)
                {
                    for (int i = 0; i < Data.GetLength(0); i++)
                    {
                        for (int j = 0; j < Data.GetLength(1)-1; j++)
                        {
                            if (Data[i, j].HasValue == true)
                            {
                                if (Data[i, j + 1].HasValue == false)
                                {
                                    Data[i, j + 1] = Data[i, j];
                                    Data[i, j] = null;
                                }
                                else if (Data[i, j + 1] == Data[i, j])
                                {
                                    Data[i, j + 1] = Data[i, j] * 2;
                                    Points += Data[i, j] * 2;
                                    if (Data[i, j] * 2 == 2048)
                                    {
                                        GameStatus _gamestatus = GameStatus.Win;
                                        Points = -2;
                                    }
                                    Data[i, j] = null;
                                }
                            }
                        }
                    }
                    count += 1;
                }
            }
            if (direction.ToString() == "Left")
            {
                int count = 0;
                while (count < 4)
                {
                    for (int i = 0; i < Data.GetLength(0); i++)
                    {
                        for (int j = 1; j < Data.GetLength(1); j++)
                        {
                            if (Data[i, j].HasValue == true)
                            {
                                if (Data[i, j - 1].HasValue == false)
                                {
                                    Data[i, j - 1] = Data[i, j];
                                    Data[i, j] = null;
                                }
                                else if (Data[i, j - 1] == Data[i, j])
                                {
                                    Data[i, j - 1] = Data[i, j] * 2;
                                    Points += Data[i, j] * 2;
                                    if (Data[i, j] * 2 == 2048)
                                    {
                                        GameStatus _gamestatus = GameStatus.Win;
                                        Points = -2;
                                    }
                                    Data[i, j] = null;
                                }
                            }
                        }
                    }
                    count += 1;
                }
            }
            FillAfterMoving();
            bool flag_check_nowhere_to_go = true;
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    if (Data[i, j] != old[i,j])
                    {
                        flag_check_nowhere_to_go = false;
                    }
                }
            }
            if (flag_check_nowhere_to_go == true)
            {
                Points = -1;
            }
            return Points;
        }

    }
}
