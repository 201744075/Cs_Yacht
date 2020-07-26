using System;

namespace Cs_Yacht
{
    class Player
    {
        protected int Aces = 0, Deuces = 0, Threes = 0, Fours = 0, Fives = 0, Sixes = 0, SubTotal = 0, Bonus = 0;
        protected int Choice = 0, FOAK = 0, FullHouse = 0, SStraight = 0, LStraight = 0, Yacht = 0, Total = 0, RollCount = 0, AddCount = 0;

        protected int TAces = 0, TDeuces = 0, TThrees = 0, TFours = 0, TFives = 0, TSixes = 0;
        protected int TChoice = 0, TFOAK = 0, TFullHouse = 0, TSStraight = 0, TLStraight = 0, TYacht = 0;

        protected int PAces = 0, PDeuces = 0, PThrees = 0, PFours = 0, PFives = 0, PSixes = 0;
        protected int PChoice = 0, PFOAK = 0, PFullHouse = 0, PSStraight = 0, PLStraight = 0, PYacht = 0;

        protected int[] Dice = new int[5] { 0, 0, 0, 0, 0 };
        protected int[] Lock = new int[5] { 0, 0, 0, 0, 0 };
        protected string Name;

        public void ScoreBoard(User _User1, User _User2, int Round)
        {
            TAces = 0; TDeuces = 0; TThrees = 0; TFours = 0; TFives = 0; TSixes = 0;
            TChoice = 0; TFOAK = 0; TFullHouse = 0; TSStraight = 0; TLStraight = 0; TYacht = 0;
            SubTotal = Aces + Deuces + Threes + Fours + Fives + Sixes;
            Total = Aces + Deuces + Threes + Fours + Fives + Sixes + Choice + FOAK + FullHouse + SStraight + LStraight + Yacht;
            if (SubTotal > 62)
                Bonus = 35;
            
            for (int i = 0; i < Dice.Length; i++)
            {
                switch (Dice[i])
                {
                    case 1:
                        TAces += 1;
                        break;
                    case 2:
                        TDeuces += 2;
                        break;
                    case 3:
                        TThrees += 3;
                        break;
                    case 4:
                        TFours += 4;
                        break;
                    case 5:
                        TFives += 5;
                        break;
                    case 6:
                        TSixes += 6;
                        break;
                    default:
                        break;

                }
                TChoice += Dice[i];
            }

            void ScoreWrite(string _Name, int Score1, int TScore1, int PScore1, int Score2, int TScore2, int PScore2)
            {
                Console.Write(_Name);
                if (PScore1 != 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(TScore1.ToString("D2"));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Score1.ToString("D2"));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("  ㅣ  ");
                if (PScore2 != 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(TScore2.ToString("D2"));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Score2.ToString("D2"));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("  ㅣ");
            }

            void OnlyBoard()
            {
                Console.WriteLine(" _______________________________");
                Console.WriteLine("ㅣ   Turn      ㅣ      ㅣ      ㅣ");
                Console.WriteLine("ㅣ             ㅣ      ㅣ      ㅣ");
                Console.WriteLine("ㅣ  " + Round.ToString("D2") + " / 12    ㅣ      ㅣ      ㅣ");
                Console.WriteLine("ㅣ-------------ㅣ" + _User1.Name + "ㅣ" + _User2.Name + "ㅣ");
                Console.WriteLine("ㅣCategorise   ㅣ      ㅣ      ㅣ");
                Console.WriteLine("ㅣ-------------ㅣ------ㅣ------ㅣ");
                ScoreWrite("ㅣ1.Aces       ㅣ  ", _User1.Aces, _User1.TAces, _User1.PAces, _User2.Aces, _User2.TAces, _User2.PAces);
                ScoreWrite("ㅣ2.Deuces     ㅣ  ", _User1.Deuces, _User1.TDeuces, _User1.PDeuces, _User2.Deuces, _User2.TDeuces, _User2.PDeuces);
                ScoreWrite("ㅣ3.Threes     ㅣ  ", _User1.Threes, _User1.TThrees, _User1.PThrees, _User2.Threes, _User2.TThrees, _User2.PThrees);
                ScoreWrite("ㅣ4.Fours      ㅣ  ", _User1.Fours, _User1.TFours, _User1.PFours, _User2.Fours, _User2.TFours, _User2.PFours);
                ScoreWrite("ㅣ5.Fives      ㅣ  ", _User1.Fives, _User1.TFives, _User1.PFives, _User2.Fives, _User2.TFives, _User2.PFives);
                ScoreWrite("ㅣ6.Sixes      ㅣ  ", _User1.Sixes, _User1.TSixes, _User1.PSixes, _User2.Sixes, _User2.TSixes, _User2.PSixes);
                Console.WriteLine("ㅣ-------------ㅣ------ㅣ------ㅣ");
                Console.WriteLine("ㅣSubtotal     ㅣ " + _User1.SubTotal.ToString("D2") + "/63ㅣ " + _User2.SubTotal.ToString("D2") + "/63ㅣ");
                Console.WriteLine("ㅣ+35 Bonus    ㅣ +" + _User1.Bonus.ToString("D2") + "  ㅣ +" + _User2.Bonus.ToString("D2") + "  ㅣ");
                Console.WriteLine("ㅣ-------------ㅣ------ㅣ------ㅣ");
                Console.WriteLine("ㅣ7.Choice     ㅣ  00  ㅣ  00  ㅣ");
                Console.WriteLine("ㅣ8.4 of a Kindㅣ  00  ㅣ  00  ㅣ");
                Console.WriteLine("ㅣ9.Full House ㅣ  00  ㅣ  00  ㅣ");
                Console.WriteLine("ㅣ0.S. Straightㅣ  00  ㅣ  00  ㅣ");
                Console.WriteLine("ㅣ-.L. Straightㅣ  00  ㅣ  00  ㅣ");
                Console.WriteLine("ㅣ=.Yacht      ㅣ  00  ㅣ  00  ㅣ");
                Console.WriteLine("ㅣ-------------ㅣ------ㅣ------ㅣ");
                Console.WriteLine("ㅣ             ㅣ      ㅣ      ㅣ");
                Console.WriteLine("ㅣTotal        ㅣ  00  ㅣ  00  ㅣ");
                Console.WriteLine("ㅣ_____________ㅣ______ㅣ______ㅣ");
            }

            OnlyBoard();

            if (RollCount != 0)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        if (PAces == 0)
                        {
                            Aces = TAces;
                            PAces = 1;
                            RollCount = 4;
                            Console.Clear();
                            OnlyBoard();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            ScoreBoard(_User1, _User2, Round);
                        }
                        break;
                    case ConsoleKey.D2:
                        if (PDeuces == 0)
                        {
                            Deuces = TDeuces;
                            PDeuces = 1;
                            RollCount = 4;
                            Console.Clear();
                            OnlyBoard();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            ScoreBoard(_User1, _User2, Round);
                        }
                        break;
                    case ConsoleKey.D3:
                        if (PThrees == 0)
                        {
                            Threes = TThrees;
                            PThrees = 1;
                            RollCount = 4;
                            Console.Clear();
                            OnlyBoard();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            ScoreBoard(_User1, _User2, Round);
                        }
                        break;
                    case ConsoleKey.D4:
                        if (PFours == 0)
                        {
                            Fours = TFours;
                            PFours = 1;
                            RollCount = 4;
                            Console.Clear();
                            OnlyBoard();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            ScoreBoard(_User1, _User2, Round);
                        }
                        break;
                    case ConsoleKey.D5:
                        if (PFives == 0)
                        {
                            Fives = TFives;
                            PFives = 1;
                            RollCount = 4;
                            Console.Clear();
                            OnlyBoard();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            ScoreBoard(_User1, _User2, Round);
                        }
                        break;

                    case ConsoleKey.D6:
                        if (PSixes == 0)
                        {
                            Sixes = TSixes;
                            PSixes = 1;
                            RollCount = 4;
                            Console.Clear();
                            OnlyBoard();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            ScoreBoard(_User1, _User2, Round);
                        }
                        break;

                    case ConsoleKey.D7:
                        if (PChoice == 0)
                        {
                            Choice = TChoice;
                            PChoice = 1;
                            RollCount = 4;
                            Console.Clear();
                            OnlyBoard();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            ScoreBoard(_User1, _User2, Round);
                        }
                        break;

                    case ConsoleKey.D8:
                        if (PFOAK == 0)
                        {
                            FOAK = TFOAK;
                            PFOAK = 1;
                            RollCount = 4;
                            Console.Clear();
                            OnlyBoard();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            ScoreBoard(_User1, _User2, Round);
                        }
                        break;

                    case ConsoleKey.D9:
                        if (PFullHouse == 0)
                        {
                            FullHouse = TFullHouse;
                            PFullHouse = 1;
                            RollCount = 4;
                            Console.Clear();
                            OnlyBoard();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            ScoreBoard(_User1, _User2, Round);
                        }
                        break;

                    case ConsoleKey.D0:
                        if (PSStraight == 0)
                        {
                            SStraight = TSStraight;
                            PSStraight = 1;
                            RollCount = 4;
                            Console.Clear();
                            OnlyBoard();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            ScoreBoard(_User1, _User2, Round);
                        }
                        break;

                    case ConsoleKey.OemMinus:
                        if (PLStraight == 0)
                        {
                            LStraight = TLStraight;
                            PLStraight = 1;
                            RollCount = 4;
                            Console.Clear();
                            OnlyBoard();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            ScoreBoard(_User1, _User2, Round);
                        }
                        break;

                    case ConsoleKey.OemPlus:
                        if (PYacht == 0)
                        {
                            Yacht = TYacht;
                            PYacht = 1;
                            RollCount = 4;
                            Console.Clear();
                            OnlyBoard();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            ScoreBoard(_User1, _User2, Round);
                        }
                        break;

                    default:
                        return;

                }
            }
            else
            {
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
