/* Challenge 13
 *
 * Write a program for a game where the computer generates
 * a random starting number between 20 and 30. The player
 * and the computer can remove 1,2 or 3 from the number in turns.
 *
 * The player who has to remove the last value to bring
 * the number down to 0 is the loser.
 *
 * Easy option:
 * Get the computer to choose a number between 1 and 3 at random
 *
 * Hard option:
 * Get the computer to employ a strategy to try and win
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge13
{
    class Challenge13
    {
        public static int GameNum;
        public static bool AiTurn;
        public static Random RandInt = new Random();
        static void Main(string[] args)
        {
            int startNum = RandInt.Next(20, 30);
            Console.WriteLine("The player to end on 0 is the loser.");
            Console.WriteLine();
            Console.WriteLine("Starting number: {0}", startNum);
            Console.WriteLine();
            GameNum = startNum;
            Game();
        }

        public static void Game()
        {
            if (GameNum > 0) {
                PlayerTurn();
            } else {
                GameEnd();
            }
        }

        public static void PlayerTurn()
        {
            AiTurn = false;

            Console.Write("How many do you want to remove? ");
            int playerRemove = ConvertInput(Console.ReadLine());

            if ((playerRemove <= 3) && (playerRemove > 0)) {
                GameNum -= playerRemove;
                Console.WriteLine("{0} left", GameNum);
                ComputerTurn();
            } else {
                Console.WriteLine("Not a number between 1 and 3");
                PlayerTurn();
            }
        }

        public static void ComputerTurn()
        {
            if (GameNum <= 0) {
                Game();
            } else if (GameNum == 1) {
                AiTurn = true;
                Console.WriteLine("Computer removes 1");
                GameNum -= 1;
                Console.WriteLine("{0} left", GameNum);
                Game();
            } else if (GameNum <= 4) {
                AiTurn = true;
                Console.WriteLine("Computer removes {0}", GameNum - 1);
                GameNum -= (GameNum - 1);
                Console.WriteLine("{0} left", GameNum);
                Game();
            } else {
                AiTurn = true;
                int diff = GameNum % 4;

                switch (diff) {
                    case 3:
                        Console.WriteLine("Computer removes 2");
                        GameNum -= 2;
                        Console.WriteLine("{0} left", GameNum);
                        break;
                    case 2:
                        Console.WriteLine("Computer removes 1");
                        GameNum -= 1;
                        Console.WriteLine("{0} left", GameNum);
                        break;
                    case 1:
                        int randInt = RandInt.Next(1, 4);
                        Console.WriteLine("Computer removes {0}", randInt);
                        GameNum -= randInt;
                        Console.WriteLine("{0} left", GameNum);
                        break;
                    default:
                        Console.WriteLine("Computer removes 3");
                        GameNum -= 3;
                        Console.WriteLine("{0} left", GameNum);
                        break;
                }
                Game();
            }
        }

        public static void GameEnd()
        {
            if (AiTurn) {
                Console.WriteLine("You win!");
                Environment.Exit(0);
            } else {
                Console.WriteLine("You lose.");
                Environment.Exit(0);
            }
        }

        public static int ConvertInput(string input)
        {
            int result;
            return int.TryParse(input, out result) ? result : 0;
        }
    }
}
