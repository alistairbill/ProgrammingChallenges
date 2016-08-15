/* Challenge 10
 * 
 * Make a game of rock, paper, scissors against the computer.
 * 
 * Extension
 *  - Make sure the user enters a valid entry
 *  - Add a loop structure to play several times and keep a running score
 *  - Make an enumerated variable type to store choices
 */

using System;

namespace Challenge10
{
    class Challenge10
    {
        public enum Choice
        {
            Rock,
            Paper,
            Scissors
        }

        public static Choice UserChoice, ComputerChoice;
        public static int Score;
        public static Random RandInt = new Random();
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++) {
                Game();
            }
        }

        public static void Game()
        {
            UserSelect();
            ComputerSelect();
            Console.WriteLine("You chose {0} ~ Computer chooses {1}", UserChoice, ComputerChoice);
            if (UserChoice == ComputerChoice)
            {
                Draw();
            }
            else if ((UserChoice == Choice.Rock && ComputerChoice == Choice.Scissors)
                || (UserChoice == Choice.Paper) && (ComputerChoice == Choice.Rock)
                || (UserChoice == Choice.Scissors && ComputerChoice == Choice.Paper))
            {
                Win();
            }
            else
            {
                Lose();
            }
        }

        public static void UserSelect()
        {
            Console.Write("\n\nRock, paper or scissors? ");
            var readLine = Console.ReadLine();
            if (readLine != null)
            {
                switch (readLine.ToLower())
                {
                    case "rock":
                        UserChoice = Choice.Rock;
                        break;
                    case "paper":
                        UserChoice = Choice.Paper;
                        break;
                    case "scissors":
                        UserChoice = Choice.Scissors;
                        break;
                    default:
                        UserSelect();
                        break;
                }
            }
            else
            {
                UserSelect();
            }   
        }

        public static void ComputerSelect()
        {
            int random = RandInt.Next(1, 4);
            switch (random)
            {
                case 1:
                    ComputerChoice = Choice.Rock;
                    break;
                case 2:
                    ComputerChoice=Choice.Paper;
                    break;
                case 3:
                    ComputerChoice=Choice.Scissors;
                    break;
            }
        }

        public static void Win()
        {
            Score++;
            Console.Write("You won! Score: " + Score);
        }

        public static void Draw()
        {
            Console.Write("You drew! Score: " + Score);
        }

        public static void Lose()
        {
            Score--;
            Console.Write("You lost. Score: " + Score);
        }
    }
}
