using System;

namespace Cs_Yacht
{
    class User : Player
    {
        public User(string _Name)
        {
            Name = _Name;
        }
        public void Roll(User _User1, AI _AI, int Round)
        {

        }

        public void Roll(User _User1, User _User2, int Round)
        {
            Console.Clear();
            Random rand = new Random();
            int position = 0;
            RollCount = 0;
            for (int i = 0; i < Dice.Length; i++)
            {
                Lock[i] = 0;
            }
            while (RollCount < 4)
            {
                Console.WriteLine("\n[ " + Name + " 이 주사위를 던질 차례 " + RollCount + "/3]\n\n");
                if(RollCount == 0)
                {
                    for (int i = 0; i < Dice.Length; i++)
                    {
                        Console.Write("6       ");
                    }
                }
                else
                {
                    for (int i = 0; i < Dice.Length; i++)
                    {
                        Console.Write(Dice[i] + "       ");
                    }
                }
                Console.WriteLine();
                for (int i = 0; i < Dice.Length; i++)
                {
                    if (Lock[i] == 1)
                    {
                        Console.Write("ㅡ      ");
                    }
                    else
                    {
                        Console.Write("        ");
                    }
                }
                Console.WriteLine();
                for (int i = 0; i < Dice.Length; i++)
                {
                    if (position == i)
                    {
                        Console.Write("↑      ");
                    }
                    else
                    {
                        Console.Write("        ");
                    }
                }
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        Console.Clear();
                        if (position > 0)
                        {
                            position -= 1;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        Console.Clear();
                        if (position < Dice.Length - 1)
                        {
                            position += 1;
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        if (RollCount > 0)
                        {
                            if (Lock[position] == 0)
                            {
                                Lock[position] = 1;
                            }
                            else
                            {
                                Lock[position] = 0;
                            }
                        }
                        break;
                    case ConsoleKey.B:
                        Console.Clear();
                        ScoreBoard(_User1, _User2, Round);
                        Console.Clear();
                        break;
                    case ConsoleKey.R:
                        Console.Clear();
                        if (RollCount < 3)
                        {
                            for (int i = 0; i < Dice.Length; i++)
                            {
                                if (Lock[i] == 0)
                                {
                                    Dice[i] = rand.Next(1, 7);
                                }
                            }
                            RollCount++;
                        }
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        public void Roll(User _User1, User _User2, User _User3, int Round)
        {

        }

        public void Roll(User _User1, User _User2, User _User3, User _User4, int Round)
        {

        }

    }
}
